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
        private readonly ICartIdentifier cardIdentifier;

        public CheckoutController(
            IShoppingCart shoppingCart,
            IOrderFactory orderFactory,
            ICartIdentifier cardIdentifier)
        {
            if (shoppingCart == null)
            {
                throw new ArgumentNullException(nameof(shoppingCart));
            }

            if (orderFactory == null)
            {
                throw new ArgumentNullException(nameof(orderFactory));
            }

            if (cardIdentifier == null)
            {
                throw new ArgumentNullException(nameof(cardIdentifier));
            }

            this.shoppingCart = shoppingCart;
            this.orderFactory = orderFactory;
            this.cardIdentifier = cardIdentifier;
        }

        public ActionResult Pay()
        {
            PaymentAddressViewModel paymentAddressVM = new PaymentAddressViewModel();
            paymentAddressVM.City = new SelectList(new string[] { "Sofia", "Plovdiv" });

            return View(paymentAddressVM);
        }

        [HttpPost]
        public ActionResult Pay(PaymentAddressViewModel pymentAddressVM)
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

                var shoppingCartId = cardIdentifier.GetCardId(this.HttpContext);
                var cart = shoppingCart.GetShoppingCart(shoppingCartId);

                var orderId = cart.SaveOrder(order);

                return RedirectToAction("Complete", new { id = orderId });
            }

            return View(pymentAddressVM);
        }

        public ActionResult Complete(int id)
        {
            var shoppingCartId = cardIdentifier.GetCardId(this.HttpContext);
            var cart = shoppingCart.GetShoppingCart(shoppingCartId);

            return View(id);
        }
    }
}