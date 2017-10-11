using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
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

            // Act && Assert
            Assert.That(() => new ShoppingCartController(shoppingCartMock, cartIdentifierMock.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenInvalidICartIdentifierParameterIsPassed()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            ICartIdentifier cartIdentifierMock = null;

            // Act && Assert
            Assert.That(() => new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void CreateShoppingCartController_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

            //Act
            ShoppingCartController shoppingCartController = new ShoppingCartController(shoppingCartMock.Object, cartIdentifierMock.Object);

            // Assert
            Assert.That(shoppingCartController, Is.Not.Null);
        }
    }
}
