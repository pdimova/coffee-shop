﻿using CoffeeShop.Logic.Cart;
using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.ShoppingCart.Abstract;
using CoffeeShop.WebUI.ViewModels.ShoppingCart.Factory;
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
    public class Index_Should
    {
        [Test]
        public void CallGetCardId_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            Mock<IShoppingCartViewModel> shoppingCartViewModel = new Mock<IShoppingCartViewModel>();

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
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCartItems()).Returns(cartItemsList);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum());
            shoppingCartViewModelFactory.Setup(m => m.CreateShoppingCartViewModel()).Returns(shoppingCartViewModel.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);

            //Act
            shoppingCartController.Index();

            // Assert
            cartIdentifierMock.Verify(m => m.GetCardId(It.IsAny<HttpContextBase>()), Times.Once());
        }

        [Test]
        public void CallGetShoppingCart_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            Mock<IShoppingCartViewModel> shoppingCartViewModel = new Mock<IShoppingCartViewModel>();

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
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCartItems()).Returns(cartItemsList);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum());
            shoppingCartViewModelFactory.Setup(m => m.CreateShoppingCartViewModel()).Returns(shoppingCartViewModel.Object);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);

            //Act
            shoppingCartController.Index();

            // Assert
            shoppingCartMock.Verify(m => m.GetShoppingCart(It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void GetCartItemsFromShoppingCart_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            Mock<IShoppingCartViewModel> shoppingCartViewModel = new Mock<IShoppingCartViewModel>();

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
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCartItems()).Returns(cartItemsList);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum());
            shoppingCartViewModelFactory.Setup(m => m.CreateShoppingCartViewModel()).Returns(shoppingCartViewModel.Object);
            shoppingCartViewModel.SetupProperty(p => p.CartItems);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);

            //Act
            shoppingCartController.Index();

            // Assert
            shoppingCartMock.Verify(m => m.GetCartItems(), Times.Once());
            Assert.That(shoppingCartViewModel.Object.CartItems, Is.EquivalentTo(cartItemsList));
        }

        [Test]
        public void GetGetTotalFromShoppingCart_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            Mock<IShoppingCartViewModel> shoppingCartViewModel = new Mock<IShoppingCartViewModel>();

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
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCartItems()).Returns(cartItemsList);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum());
            shoppingCartViewModelFactory.Setup(m => m.CreateShoppingCartViewModel()).Returns(shoppingCartViewModel.Object);
            shoppingCartViewModel.SetupProperty(p => p.CartTotal);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);

            //Act
            shoppingCartController.Index();

            // Assert
            shoppingCartMock.Verify(m => m.GetTotal(), Times.Once());
            Assert.That(shoppingCartViewModel.Object.CartTotal, Is.EqualTo(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum()));
        }

        [Test]
        public void SetViewBag_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            Mock<IShoppingCartViewModel> shoppingCartViewModel = new Mock<IShoppingCartViewModel>();

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
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCartItems()).Returns(cartItemsList);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum());
            shoppingCartViewModelFactory.Setup(m => m.CreateShoppingCartViewModel()).Returns(shoppingCartViewModel.Object);
            shoppingCartViewModel.SetupProperty(p => p.CartTotal);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);
            shoppingCartController.TempData["City"] = "Sofia";
            //Act
            shoppingCartController.Index();

            // Assert
            Assert.That(shoppingCartController.ViewBag.City, Is.EqualTo(shoppingCartController.TempData["City"]));
        }

        [Test]
        public void ReturnViewResult_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            Mock<HttpContextBase> httpContextBaseMock = new Mock<HttpContextBase>();
            Mock<IShoppingCartViewModel> shoppingCartViewModel = new Mock<IShoppingCartViewModel>();

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
                }
            };

            cartIdentifierMock.Setup(m => m.GetCardId(It.IsAny<HttpContextBase>())).Returns(id);
            shoppingCartMock.Setup(m => m.GetShoppingCart(It.IsAny<string>())).Returns(shoppingCartMock.Object);
            shoppingCartMock.Setup(m => m.GetCartItems()).Returns(cartItemsList);
            shoppingCartMock.Setup(m => m.GetTotal()).Returns(cartItemsList.Select(c => c.Count * c.CoffeeCost).Sum());
            shoppingCartViewModelFactory.Setup(m => m.CreateShoppingCartViewModel()).Returns(shoppingCartViewModel.Object);
            shoppingCartViewModel.SetupProperty(p => p.CartTotal);

            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);

            //Act
            var result = shoppingCartController.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}