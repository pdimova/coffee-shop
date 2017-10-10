using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI.ViewModels.Checkout;
using CoffeeShop.WebUI.ViewModels.Checkout.Abstract;
using CoffeeShop.WebUI.ViewModels.Checkout.Factory;
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
        private readonly IPaymentAddressViewModelFactory paymentAddressViewModelFactory;

        public CheckoutController(
            IShoppingCart shoppingCart,
            IOrderFactory orderFactory,
            ICartIdentifier cardIdentifier,
            IPaymentAddressViewModelFactory paymentAddressViewModelFactory)
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

            if (paymentAddressViewModelFactory == null)
            {
                throw new ArgumentNullException(nameof(paymentAddressViewModelFactory));
            }

            this.shoppingCart = shoppingCart;
            this.orderFactory = orderFactory;
            this.cardIdentifier = cardIdentifier;
            this.paymentAddressViewModelFactory = paymentAddressViewModelFactory;
        }

        public ActionResult Pay()
        {
            IPaymentAddressViewModel paymentAddressVM = paymentAddressViewModelFactory.CreatePaymentAddressViewModel();
            paymentAddressVM.City = new SelectList(new string[] { "Sofia", "Plovdiv" });

            return View(paymentAddressVM);
        }

        [HttpPost]
        public ActionResult Pay(IPaymentAddressViewModel pymentAddressVM)
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