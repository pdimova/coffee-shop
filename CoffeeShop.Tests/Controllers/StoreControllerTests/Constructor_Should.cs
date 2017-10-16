using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeShop.Tests.Controllers.StoreControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateStoreController_WhenParametersAreNotNull()
        {
            // Arrange
            Mock<ICoffeeStore> storeMock = new Mock<ICoffeeStore>();
            Mock<IMenuProvider> menuProviderMock = new Mock<IMenuProvider>();
            Mock<IProcessingOrderFactory> orderFactoryMock = new Mock<IProcessingOrderFactory>();


            //Act
            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);

            // Assert
            Assert.That(storeController, Is.Not.Null);
        }

        [Test]
        public void ThrowArgumentNullException_WhenStoreParameterIsNull()
        {
            // Arrange
            ICoffeeStore storeMock = null;
            Mock<IMenuProvider> menuProviderMock = new Mock<IMenuProvider>();
            Mock<IProcessingOrderFactory> orderFactoryMock = new Mock<IProcessingOrderFactory>();

            // Act && Assert
            Assert.That(() => new StoreController(storeMock, menuProviderMock.Object, orderFactoryMock.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenMenuProviderParameterIsNull()
        {
            // Arrange
            Mock<ICoffeeStore> storeMock = new Mock<ICoffeeStore>();
            IMenuProvider menuProviderMock = null;
            Mock<IProcessingOrderFactory> orderFactoryMock = new Mock<IProcessingOrderFactory>();

            // Act && Assert
            Assert.That(() => new StoreController(storeMock.Object, menuProviderMock, orderFactoryMock.Object),
                Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ThrowArgumentNullException_WhenrocessingOrderFactoryParameterIsNull()
        {
            // Arrange
            Mock<ICoffeeStore> storeMock = new Mock<ICoffeeStore>();
            Mock<IMenuProvider> menuProviderMock = new Mock<IMenuProvider>();
            IProcessingOrderFactory orderFactoryMock = null;

            // Act && Assert
            Assert.That(() => new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock),
                Throws.TypeOf<ArgumentNullException>());
        }
    }
}
