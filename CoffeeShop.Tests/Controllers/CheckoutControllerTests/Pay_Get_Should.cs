using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.Checkout;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.CheckoutControllerTests
{
    [TestFixture]
    public class Pay_Get_Should
    {

        [Test]
        public void ReturnView()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            Mock<PaymentAddressViewModel> paymentAddressViewModelMock = new Mock<PaymentAddressViewModel>();

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object);

            //Act
            var result = checkoutController.Pay();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
