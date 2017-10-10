using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.Checkout.Abstract;
using CoffeeShop.WebUI.ViewModels.Checkout.Factory;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.CheckoutControllerTests
{
    [TestFixture]
    public class Pay_Get_Should
    {
        [Test]
        public void GetPaymentAddressViewModel()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            Mock<IPaymentAddressViewModel> paymentAddressViewModelMock = new Mock<IPaymentAddressViewModel>();
            paymentAddressViewModelFactoryMock.Setup(m => m.CreatePaymentAddressViewModel()).Returns(paymentAddressViewModelMock.Object);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            //Act
            checkoutController.Pay();

            // Assert
            paymentAddressViewModelFactoryMock.Verify(m => m.CreatePaymentAddressViewModel(), Times.Once());
        }

        [Test]
        public void SetCityPropertyOfPaymentAddressViewModel()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            var cities = new SelectList(new string[] { "Sofia", "Plovdiv" });
            Mock<IPaymentAddressViewModel> paymentAddressViewModelMock = new Mock<IPaymentAddressViewModel>();
            paymentAddressViewModelFactoryMock.Setup(m => m.CreatePaymentAddressViewModel()).Returns(paymentAddressViewModelMock.Object);
            paymentAddressViewModelMock.SetupProperty(p => p.City);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            //Act
            checkoutController.Pay();

            // Assert
            Assert.That(paymentAddressViewModelMock.Object.City.Items, Is.EquivalentTo(cities.Items));

        }

        [Test]
        public void ReturnView()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            Mock<IPaymentAddressViewModel> paymentAddressViewModelMock = new Mock<IPaymentAddressViewModel>();
            paymentAddressViewModelFactoryMock.Setup(m => m.CreatePaymentAddressViewModel()).Returns(paymentAddressViewModelMock.Object);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            //Act
            var result = checkoutController.Pay();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
