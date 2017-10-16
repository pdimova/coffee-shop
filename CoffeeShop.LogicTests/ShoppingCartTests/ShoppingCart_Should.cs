using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.Cart.Factory;
using CoffeeShop.Logic.Cart.Repository;
using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.Order.Repository;
using CoffeeShop.Logic.ShoppingCart;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.LogicTests.ShoppingCartTests
{
    [TestFixture]
    public class ShoppingCart_Should
    {
        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenInvalidICartRepositoryParameter()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            // Act && Assert
            Assert.That(() => new ShoppingCart(null, cartFactoryMock.Object, orderRepositoryMock.Object), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenInvalidICartFactoryParameter()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            // Act && Assert
            Assert.That(() => new ShoppingCart(cartRepositoryMock.Object, null, orderRepositoryMock.Object), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenInvalidIOrderRepositoryParameter()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            // Act && Assert
            Assert.That(() => new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_CreatesNewInstance_WhenValidParametersPassed()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            // Act
            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);

            // Asssert
            Assert.That(shoppingCart, Is.Not.Null.And.InstanceOf<IShoppingCart>());
        }

        [Test]
        public void AddToCart_SetCoffeeIdPropertyOfICart()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            cartFactoryMock.Setup(m => m.CreateCart()).Returns(cartMock.Object);
            coffeeMock.SetupGet(p => p.Id).Returns("coffeeId");
            cartMock.SetupProperty(p => p.CoffeeId).Verify();

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            coffeeMock.Verify(p => p.Id, Times.AtLeastOnce());
            Assert.That(cartMock.Object.CoffeeId, Is.EqualTo(coffeeMock.Object.Id));
        }

        [Test]
        public void AddToCart_SetCoffeeDescriptionPropertyIdOfICart()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            cartFactoryMock.Setup(m => m.CreateCart()).Returns(cartMock.Object);
            coffeeMock.SetupGet(p => p.FullDescription).Returns("coffeedescriptiontest");
            cartMock.SetupProperty(p => p.CoffeeDescription).Verify();

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            coffeeMock.Verify(p => p.FullDescription, Times.Once());
            Assert.That(cartMock.Object.CoffeeDescription, Is.EqualTo(coffeeMock.Object.FullDescription));
        }

        [Test]
        public void AddToCart_SetCoffeeCostPropertyIdOfICart()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            cartFactoryMock.Setup(m => m.CreateCart()).Returns(cartMock.Object);
            coffeeMock.Setup(m => m.Cost()).Returns(3m);
            cartMock.SetupProperty(p => p.CoffeeCost).Verify();

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            coffeeMock.Verify(m => m.Cost(), Times.Once());
            Assert.That(cartMock.Object.CoffeeCost, Is.EqualTo(coffeeMock.Object.Cost()));
        }

        [Test]
        public void AddToCart_SetShoppingCartPropertyIdOfICart()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            cartFactoryMock.Setup(m => m.CreateCart()).Returns(cartMock.Object);
            cartMock.SetupProperty(p => p.ShoppingCartId);

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            var id = "test";
            shoppingCart.ShoppingCartId = id;
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            Assert.That(cartMock.Object.ShoppingCartId, Is.Not.Null.And.EqualTo(id));
        }

        [Test]
        public void AddToCart_SetCountPropertyIdOfICart()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            cartFactoryMock.Setup(m => m.CreateCart()).Returns(cartMock.Object);
            cartMock.SetupProperty(p => p.Count);

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            Assert.That(cartMock.Object.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddToCart_CallAddToRepository()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(false);
            cartFactoryMock.Setup(m => m.CreateCart()).Returns(cartMock.Object);

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            cartRepositoryMock.Verify(m => m.Add(It.IsAny<ICart>()), Times.Once());
        }

        [Test]
        public void AddToCart_CallGetCartItemByCoffeeId()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cartRepositoryMock.Setup(m => m.GetCartItemByCoffeeId(It.IsAny<string>(), It.IsAny<string>())).Returns(cartMock.Object);
 
            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert
            cartRepositoryMock.Verify(m => m.GetCartItemByCoffeeId(It.IsAny<string>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public void AddToCart_IncreaseCountProperty()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cartRepositoryMock.Setup(m => m.GetCartItemByCoffeeId(It.IsAny<string>(), It.IsAny<string>())).Returns(cartMock.Object);
            cartMock.SetupProperty(f => f.Count, 1);

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert

            Assert.That(cartMock.Object.Count, Is.EqualTo(2));
        }

        [Test]
        public void AddToCart_CallUpdate()
        {
            // Arrange
            var cartRepositoryMock = new Mock<ICartRepository>();
            var cartFactoryMock = new Mock<ICartFactory>();
            var orderRepositoryMock = new Mock<IOrderRepository>();
            var coffeeMock = new Mock<ICoffee>();
            var cartMock = new Mock<ICart>();

            cartRepositoryMock.Setup(m => m.IsCartItemAvailable(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            cartRepositoryMock.Setup(m => m.GetCartItemByCoffeeId(It.IsAny<string>(), It.IsAny<string>())).Returns(cartMock.Object);
            cartMock.SetupProperty(f => f.Count, 1);

            var shoppingCart = new ShoppingCart(cartRepositoryMock.Object, cartFactoryMock.Object, orderRepositoryMock.Object);
            // Act
            shoppingCart.AddToCart(coffeeMock.Object);

            // Asssert

            cartRepositoryMock.Verify(m => m.Update(It.IsAny<ICart>()), Times.Once());
        }
    }
}
