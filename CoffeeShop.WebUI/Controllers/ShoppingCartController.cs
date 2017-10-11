using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI.ViewModels.ShoppingCart;
using System;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCart shoppingCart;
        private readonly ICartIdentifier cardIdentifier;

        public ShoppingCartController(
            IShoppingCart shoppingCart,
            ICartIdentifier cardIdentifier)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(nameof(shoppingCart));
            }

            if (cardIdentifier == null)
            {
                throw new ArgumentNullException(nameof(cardIdentifier));
            }

            this.shoppingCart = shoppingCart;
            this.cardIdentifier = cardIdentifier;
        }

        public ActionResult Index()
        {
            string cartId = cardIdentifier.GetCardId(this.HttpContext);
            IShoppingCart cart = shoppingCart.GetShoppingCart(cartId);

            ShoppingCartViewModel viewModel = new ShoppingCartViewModel();
            viewModel.CartItems = cart.GetCartItems();
            viewModel.CartTotal = cart.GetTotal();

            ViewBag.City = TempData["City"];

            return View(viewModel);
        }

        public ActionResult AddToCart()
        {
            var oderedCoffee = TempData["Order"] as ICoffee; // meh

            string cartId = cardIdentifier.GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(cartId);

            cart.AddToCart(oderedCoffee);

            return RedirectToAction("Index");
        }

        [HttpPost] // AJAX
        public ActionResult RemoveFromCart(string id)
        {
            var shoppingCartId = cardIdentifier.GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(shoppingCartId);

            int itemCount = cart.RemoveFromCart(id);

            ShoppingCartRemoveViewModel results = new ShoppingCartRemoveViewModel();
            results.Message = "Order has been removed from your shopping cart.";
            results.CartTotal = cart.GetTotal();
            results.CartCount = cart.GetCount();
            results.ItemCount = itemCount;
            results.DeleteId = id;

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