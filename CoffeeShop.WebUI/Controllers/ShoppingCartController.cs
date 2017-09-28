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

        public ShoppingCartController(IShoppingCart shoppingCart)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(nameof(shoppingCart));
            }

            this.shoppingCart = shoppingCart;
        }


        public ActionResult Index()
        {
            var cartId = GetCardId(this.HttpContext);
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

            string cartId = GetCardId(this.HttpContext);

            var cart = shoppingCart.GetShoppingCart(cartId);
            cart.AddToCart(oderedCoffee);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(string id)
        {
   
            var shoppingCartId = GetCardId(this.HttpContext);
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
            var shoppingCartId = GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(shoppingCartId);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

        private string GetCardId(HttpContextBase context)
        {
            if (context.Session["CartId"] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session["CartId"] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session["CartId"] = tempCartId.ToString();
                }
            }
            return context.Session["CartId"].ToString();
        }
    }
}