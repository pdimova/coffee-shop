using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.Checkout.Factory;
using Moq;
using NUnit.Framework;
using System;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.CheckoutControllerTests
{
    [TestFixture]
    public class Complete_Should
    {
        [Test]
        public void CallGetCardId_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            var orderOd = 1;
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            //Act
            checkoutController.Complete(orderOd);

            // Assert
            cartIdentifierMock.Verify(m => m.GetCardId(It.IsAny<HttpContextBase>()), Times.Once());
        }

        [Test]
        public void CallGetShoppingCart_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            var orderOd = 1;
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            //Act
            checkoutController.Complete(orderOd);

            // Assert
            shoppingCartMock.Verify(m => m.GetShoppingCart(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void ReturnView()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            var orderOd = 1;
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);

            //Act
            var result = checkoutController.Complete(orderOd);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}