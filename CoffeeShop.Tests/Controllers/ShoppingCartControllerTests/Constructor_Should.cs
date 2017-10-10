using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.ShoppingCart.Factory;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeShop.Tests.Controllers.ShoppingCartControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {

        [Test]
        public void ThrowArgumentNullException_WhenInvalidIShoppingCartParameterIsPassed()
        {
            // Arrange
            IShoppingCart shoppingCartMock = null;
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();


            // Act && Assert
            Assert.That(() => new ShoppingCartController(shoppingCartMock, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidICartIdentifierParameterIsPassed()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            ICartIdentifier cartIdentifierMock = null;
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            // Act && Assert
            Assert.That(() => new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock, shoppingCartViewModelFactory.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidIShoppingCartViewModelFactoryParameterIsPassed()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            IShoppingCartViewModelFactory shoppingCartViewModelFactory = null;

            // Act && Assert
            Assert.That(() => new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CreateShoppingCartController_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IShoppingCartViewModelFactory> shoppingCartViewModelFactory = new Mock<IShoppingCartViewModelFactory>();

            //Act
            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object, shoppingCartViewModelFactory.Object);

            // Assert
            Assert.That(shoppingCartController, Is.Not.Null);
        }
    }
}
