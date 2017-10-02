using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI.ViewModels.ShoppingCart;
using System;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart shoppingCart;
        private readonly CartIdentifier cardIdentifier;

        public ShoppingCartController(IShoppingCart shoppingCart, CartIdentifier cardIdentifier) // maybe shoppingCartFactory ??
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(nameof(shoppingCart));
            }

            this.shoppingCart = shoppingCart;
            this.cardIdentifier = cardIdentifier;
        }


        public ActionResult Index()
        {
            var cartId = cardIdentifier.GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(cartId);


            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };


            return View(viewModel);
        }

        public ActionResult AddToCart()
        {
            var oderedCoffee = TempData["order"] as ICoffee; // so wrong

            string cartId = cardIdentifier.GetCardId(this.HttpContext);

            var cart = shoppingCart.GetShoppingCart(cartId);
            cart.AddToCart(oderedCoffee);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(string id)
        {

            var shoppingCartId = cardIdentifier.GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(shoppingCartId);


            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = "Order has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var shoppingCartId = cardIdentifier.GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(shoppingCartId);

            ViewData["CartCount"] = cart.GetCount();

            return PartialView("CartSummary");
        }


    }
}