using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI.ViewModels.Checkout;
using System;
using System.Web.Mvc;

namespace CoffeeShop.WebUI.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IOrderFactory orderFactory;

        public CheckoutController(IShoppingCart shoppingCart, IOrderFactory orderFactory)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(nameof(shoppingCart));
            }

            if (orderFactory == null)
            {
                throw new ArgumentNullException(nameof(orderFactory));
            }

            this.shoppingCart = shoppingCart;
            this.orderFactory = orderFactory;
        }

        public ActionResult Pay()
        {
            var model = new PaymentAddressViewModel();
            model.City = new SelectList(new string[] { "Sofia", "Plovdiv" });

            return View(model);
        }

        [HttpPost]
        public ActionResult Pay(PaymentAddressViewModel form)
        {

            if (ModelState.IsValid)
            {
                // from orderViewModel to Logic.Order
                // from Logic.Order to OrderDBModel
                // from OrderDBModel to Logic.Order
                // Logic.Order to orderViewModel or simply take the OrderId

                var order = orderFactory.CreateOrder();

                TryUpdateModel(order);

                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                var shoppingCartId = (string)this.HttpContext.Session["CartId"];
                var cart = shoppingCart.GetShoppingCart(shoppingCartId);

                var orderId = cart.SaveOrder(order);

                return RedirectToAction("Complete", new { id = orderId });
            }

            return View(form);
        }

        public ActionResult Complete(int id)
        {
            var shoppingCartId = (string)this.HttpContext.Session["CartId"];
            var cart = shoppingCart.GetShoppingCart(shoppingCartId);

            return View(id);
        }
    }
}