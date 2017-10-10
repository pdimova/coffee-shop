using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.Checkout.Factory;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeShop.Tests.Controllers.CheckoutControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenInvalidIShoppingCartParameterIsPassed()
        {
            // Arrange
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();


            // Act && Assert
            Assert.That(() => new CheckoutController(null, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidIOrderFactoryParameterIsPassed()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();


            // Act && Assert
            Assert.That(() => new CheckoutController(shoppingCartMock.Object, null, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidICartIdentifierParameterIsPassed()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();


            // Act && Assert
            Assert.That(() => new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, null, paymentAddressViewModelFactoryMock.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidIPaymentAddressViewModelFactoryParameterIsPassed()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();


            // Act && Assert
            Assert.That(() => new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, null),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CreateCheckoutController_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            //Act
            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            // Assert
            Assert.That(checkoutController, Is.Not.Null);
        }
    }
}
