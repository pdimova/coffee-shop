using CoffeeShop.Logic.Cart;
using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.ShoppingCart;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.ShoppingCartControllerTests
{
    [TestFixture]
    public class RemoveFromCart_Should
    {
        [Test]
        public void CallGetCardId()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            var coffeeId = "ESP";
            Mock<ShoppingCartRemoveViewModel> shoppingCartRemoveViewModel = new Mock<ShoppingCartRemoveViewModel>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.RemoveFromCart(coffeeId);

            // Assert
            cartIdentifierMock.Verify(m => m.GetCardId(It.IsAny<HttpContextBase>()), Times.Once());
        }

        [Test]
        public void CallGetShoppingCart()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            var coffeeId = "ESP";
            Mock<ShoppingCartRemoveViewModel> shoppingCartRemoveViewModel = new Mock<ShoppingCartRemoveViewModel>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.RemoveFromCart(coffeeId);

            // Assert
            shoppingCartMock.Verify(m => m.GetShoppingCart(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void CallRemoveFromCart()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            var coffeeId = "ESP";
            Mock<ShoppingCartRemoveViewModel> shoppingCartRemoveViewModel = new Mock<ShoppingCartRemoveViewModel>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.RemoveFromCart(It.IsAny<string>())).Returns(10);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.RemoveFromCart(coffeeId);

            // Assert
            shoppingCartMock.Verify(m => m.RemoveFromCart(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void SetCartTotalProperty()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            var coffeeId = "ESP";
            var count = 10;
            Mock<ShoppingCartRemoveViewModel> shoppingCartRemoveViewModel = new Mock<ShoppingCartRemoveViewModel>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();
            var cartItemsList = new List<ICart>()
            {
                new Cart()
                {
                    CoffeeId = "ESP",
                    CoffeeCost = 3.24m,
                    Count = 1,
                    CoffeeDescription = "Grande Espresso",
                    ShoppingCartId = id
                },

                new Cart()
                {
                    CoffeeId = "AM",
                    CoffeeCost = 2.50m,
                    Count = 1,
                    CoffeeDescription = "Small Americano",
                    ShoppingCartId = id
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.RemoveFromCart(It.IsAny<string>())).Returns(count);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.CoffeeCost).Sum());

            shoppingCartRemoveViewModel.SetupProperty(p => p.CartTotal);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.RemoveFromCart(coffeeId);

            // Assert
            shoppingCartMock.Verify(m => m.GetTotal(), Times.Once());
        }

        [Test]
        public void SetCartCountProperty()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            var coffeeId = "ESP";
            var count = 10;
            Mock<ShoppingCartRemoveViewModel> shoppingCartRemoveViewModel = new Mock<ShoppingCartRemoveViewModel>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();
            var cartItemsList = new List<ICart>()
            {
                new Cart()
                {
                    CoffeeId = "ESP",
                    CoffeeCost = 3.24m,
                    Count = 1,
                    CoffeeDescription = "Grande Espresso",
                    ShoppingCartId = id
                },

                new Cart()
                {
                    CoffeeId = "AM",
                    CoffeeCost = 2.50m,
                    Count = 1,
                    CoffeeDescription = "Small Americano",
                    ShoppingCartId = id
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.RemoveFromCart(It.IsAny<string>())).Returns(count);
            shoppingCartMock.Setup(m => m.GetCount()).Returns(cartItemsList.Count());

            shoppingCartRemoveViewModel.SetupProperty(p => p.CartCount);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            shoppingCartController.RemoveFromCart(coffeeId);

            // Assert
            shoppingCartMock.Verify(m => m.GetCount(), Times.Once());
        }

        [Test]
        public void ReturnJson()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            var coffeeId = "ESP";
            Mock<ShoppingCartRemoveViewModel> shoppingCartRemoveViewModel = new Mock<ShoppingCartRemoveViewModel>();
            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            var id = Guid.NewGuid().ToString();

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);


            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            //Act
            var result = shoppingCartController.RemoveFromCart(coffeeId);

            // Assert
            Assert.That(result, Is.TypeOf<JsonResult>());
        }
    }
}
