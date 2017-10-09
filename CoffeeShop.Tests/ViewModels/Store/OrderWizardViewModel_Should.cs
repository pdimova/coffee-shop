using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Abstract;
using CoffeeShop.WebUI.ViewModels.Store;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Tests.ViewModels.Store
{
    [TestFixture]
    public class OrderWizardViewModel_Should
    {
        [Test]
        public void ConstructorShouldThrowArgumentNullException_WhenNullParameterIsPassed()
        {
            //Arrange
            IMenuProvider menuProviderMock = null;

            //Act & Assert
            Assert.That(() => new OrderWizardViewModel(menuProviderMock), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ConstructorShouldCreateInstance_WhenValidParameterIsPassed()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();

            //Act
            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Assert
            Assert.That(orderWizardViewModel, Is.InstanceOf<OrderWizardViewModel>());
        }

        [Test]
        public void ConstructorShouldPopulateCoffeeTypesProperty_WhenValidParameterIsPassed()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);

            //Act
            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Assert
            menuProviderMock.Verify(m => m.GetCoffeeTypes(), Times.Once());
            Assert.That(orderWizardViewModel.CoffeeTypes, Is.SameAs(coffeeTypes));
        }

        [Test]
        public void ConstructorShouldPopulateCoffeeSizesProperty_WhenValidParameterIsPassed()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);

            //Act
            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Assert
            menuProviderMock.Verify(m => m.GetCoffeeSizes(), Times.Once());
            Assert.That(orderWizardViewModel.CoffeeSizes, Is.SameAs(coffeeSizes));
        }

        [Test]
        public void ConstructorShouldPopulateCoffeeCondimentsProperty_WhenValidParameterIsPassed()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            //Act
            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Assert
            menuProviderMock.Verify(m => m.GetCoffeeCondiments(), Times.Once());

            Assert.That(orderWizardViewModel.CoffeeCondiments.ContainsKey(coffeeCondiments[0]), Is.True);
            Assert.That(orderWizardViewModel.CoffeeCondiments[coffeeCondiments[0]], Is.False);

            Assert.That(orderWizardViewModel.CoffeeCondiments.ContainsKey(coffeeCondiments[1]), Is.True);
            Assert.That(orderWizardViewModel.CoffeeCondiments[coffeeCondiments[1]], Is.False);

            Assert.That(orderWizardViewModel.CoffeeCondiments.ContainsKey(coffeeCondiments[2]), Is.True);
            Assert.That(orderWizardViewModel.CoffeeCondiments[coffeeCondiments[2]], Is.False);
        }

        [Test]
        public void SelectedCoffeeTypeShouldBeNull_AfterInitialization()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };

            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            //Act
            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Assert
            Assert.That(orderWizardViewModel.SelectedCoffeeType, Is.Null);
        }

        [Test]
        public void SelectedCoffeeSizeShouldBeNull_AfterInitialization()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };

            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            //Act
            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Assert
            Assert.That(orderWizardViewModel.SelectedCoffeeSize, Is.Null);
        }

        [Test]
        public void TransferDataTo_ShouldReturnThePassedObjectOfTypeIProcessingOrder()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var processingOrder = new Mock<IProcessingOrder>();

            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };

            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);

            //Act
            var result = orderWizardViewModel.TransferDataTo(processingOrder.Object);

            //Assert
            Assert.That(result, Is.InstanceOf<IProcessingOrder>());
            Assert.That(result, Is.SameAs(processingOrder.Object));
        }

        [Test]
        public void TransferDataTo_ShouldPopulateSelectedCoffeeTypePropertyOfPassedObject()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var processingOrder = new Mock<IProcessingOrder>();

            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };

            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            processingOrder.SetupProperty(p => p.SelectedCoffeeType); //start "tracking" sets/gets to this property

            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);
            orderWizardViewModel.SelectedCoffeeType = coffeeTypes[1];
            orderWizardViewModel.SelectedCoffeeSize = coffeeSizes[1];
            orderWizardViewModel.CoffeeCondiments[coffeeCondiments[1]] = true;

            //Act
            var result = orderWizardViewModel.TransferDataTo(processingOrder.Object);

            //Assert
            Assert.That(result.SelectedCoffeeType, Is.EqualTo(orderWizardViewModel.SelectedCoffeeType));
        }

        [Test]
        public void TransferDataTo_ShouldPopulateSelectedCoffeeSizePropertyOfPassedObject()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var processingOrder = new Mock<IProcessingOrder>();

            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };

            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            processingOrder.SetupProperty(p => p.SelectedCoffeeSize);

            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);
            orderWizardViewModel.SelectedCoffeeType = coffeeTypes[1];
            orderWizardViewModel.SelectedCoffeeSize = coffeeSizes[1];
            orderWizardViewModel.CoffeeCondiments[coffeeCondiments[1]] = true;

            //Act
            var result = orderWizardViewModel.TransferDataTo(processingOrder.Object);

            //Assert
            Assert.That(result.SelectedCoffeeSize, Is.EqualTo(orderWizardViewModel.SelectedCoffeeSize));
        }

        [Test]
        public void TransferDataTo_ShouldPopulateSelectedCoffeeCodimentsListOfPassedObject()
        {
            //Arrange
            var menuProviderMock = new Mock<IMenuProvider>();
            var processingOrder = new Mock<IProcessingOrder>();

            var coffeeTypes = new List<string>() { "Americano", "Latte" };
            var coffeeSizes = new List<string>() { "Grande", "Small" };
            var coffeeCondiments = new List<string>() { "Milk", "Chocolate", "Caramel" };

            menuProviderMock.Setup(m => m.GetCoffeeTypes()).Returns(coffeeTypes);
            menuProviderMock.Setup(m => m.GetCoffeeSizes()).Returns(coffeeSizes);
            menuProviderMock.Setup(m => m.GetCoffeeCondiments()).Returns(coffeeCondiments);

            processingOrder.SetupProperty(p => p.SelectedCoffeeCodimentsList);

            var orderWizardViewModel = new OrderWizardViewModel(menuProviderMock.Object);
            orderWizardViewModel.SelectedCoffeeType = coffeeTypes[1];
            orderWizardViewModel.SelectedCoffeeSize = coffeeSizes[1];
            orderWizardViewModel.CoffeeCondiments[coffeeCondiments[1]] = true;

            //Act
            var result = orderWizardViewModel.TransferDataTo(processingOrder.Object);

            //Assert
            Assert.That(result.SelectedCoffeeCodimentsList,
                Is.EquivalentTo(orderWizardViewModel.CoffeeCondiments.Where(c => c.Value == true).Select(c => c.Key)));
        }
    }
}