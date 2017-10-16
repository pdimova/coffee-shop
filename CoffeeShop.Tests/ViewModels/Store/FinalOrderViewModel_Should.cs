using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.WebUI.ViewModels.Store;
using Moq;
using NUnit.Framework;
using System;

namespace CoffeeShop.Tests.ViewModels.Store
{
    [TestFixture]
    public class FinalOrderViewModel_Should
    {
        [Test]
        public void ConstructorShouldThrowArgumentNullException_WhenNullParameterIsPassed()
        {
            //Arrange
            ICoffee coffeeMock = null;

            //Act & Assert
            Assert.That(() => new FinalOrderViewModel(coffeeMock), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorShouldCreateInstance_WhenValidParameterIsPassed()
        {
            //Arrange
            var coffeeMock = new Mock<ICoffee>();

            //Act
            var finalOrderViewModel = new FinalOrderViewModel(coffeeMock.Object);

            //Assert
            Assert.That(finalOrderViewModel, Is.InstanceOf<FinalOrderViewModel>());
        }

        [Test]
        public void ConstructorShouldPopulateFullDescriptionProperty_WhenValidParameterIsPassed()
        {
            //Arrange
            var coffeeMock = new Mock<ICoffee>();
            string description = "Americano Milk";
            coffeeMock.Setup(p => p.FullDescription).Returns(description);

            //Act
            var finalOrderViewModel = new FinalOrderViewModel(coffeeMock.Object);

            //Assert
            coffeeMock.Verify(p => p.FullDescription, Times.Once());
            Assert.That(finalOrderViewModel.FullDescription, Contains.Substring(description));
        }

        [Test]
        public void ConstructorShouldPopulatePriceProperty_WhenValidParameterIsPassed()
        {
            //Arrange
            var coffeeMock = new Mock<ICoffee>();
            decimal cost = 3.67m;
            coffeeMock.Setup(m => m.Cost()).Returns(cost);

            //Act
            var finalOrderViewModel = new FinalOrderViewModel(coffeeMock.Object);

            //Assert
            coffeeMock.Verify(p => p.FullDescription, Times.Once());
            Assert.That(finalOrderViewModel.Price, Is.EqualTo(cost));
        }
    }
}
