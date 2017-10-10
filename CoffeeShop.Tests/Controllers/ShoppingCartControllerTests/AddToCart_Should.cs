using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.ShoppingCart.Factory;
using Moq;
using NUnit.Framework;
using System;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.ShoppingCartControllerTests
{
    [TestFixture]
    public class AddToCart_Should
    {
        [Test]
        public void CallGetCardId()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<ICoffee> coffeeMock = new Mock<ICoffee>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);
            shoppingCartController.TempData["Order"] = coffeeMock.Object;

            //Act
            shoppingCartController.AddToCart();

            // Assert
            cartIdentifierMock.Verify(m => m.GetCardId(It.IsAny<HttpContextBase>()), Times.Once());
        }

        [Test]
        public void CallGetShoppingCart()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<ICoffee> coffeeMock = new Mock<ICoffee>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);
            shoppingCartController.TempData["Order"] = coffeeMock.Object;

            //Act
            shoppingCartController.AddToCart();

            // Assert
            shoppingCartMock.Verify(m => m.GetShoppingCart(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallAddToCart()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<ICoffee> coffeeMock = new Mock<ICoffee>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);
            shoppingCartController.TempData["Order"] = coffeeMock.Object;

            //Act
            shoppingCartController.AddToCart();

            // Assert
            shoppingCartMock.Verify(m => m.AddToCart(It.IsAny<ICoffee>()), Times.Once());
        }

        [Test]
        public void RedirectsToShoppingcartIndex()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<ICoffee> coffeeMock = new Mock<ICoffee>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);
            shoppingCartController.TempData["Order"] = coffeeMock.Object;

            //Act
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)shoppingCartController.AddToCart();

            // Assert
            //Assert.That(redirectResult.RouteValues["controller"], Is.EqualTo("ShoppingCart"));
            Assert.That(redirectResult.RouteValues["action"], Is.EqualTo("Index"));
        }
    }
}
