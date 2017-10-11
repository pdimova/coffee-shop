using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.ShoppingCartControllerTests
{
    [TestFixture]
    public class CartSummary_Should
    {
        [Test]
        public void CallGetCardId()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.CartSummary();

            // Assert
            cartIdentifierMock.Verify(m => m.GetCardId(It.IsAny<HttpContextBase>()), Times.Once());
        }

        [Test]
        public void CallGetShoppingCart()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.CartSummary();

            // Assert
            shoppingCartMock.Verify(m => m.GetShoppingCart(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void SetViewData()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();
            var count = 10;

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCount()).Returns(count);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.CartSummary();

            // Assert
            shoppingCartMock.Verify(m => m.GetCount(), Times.Once());
            Assert.That(shoppingCartController.ViewData["CartCount"], Is.EqualTo(count));
        }

        [Test]
        public void ReturnPartialView()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            var result = shoppingCartController.CartSummary();

            // Assert
            Assert.That(result, Is.InstanceOf<PartialViewResult>());
        }
    }
}
