using CoffeeShop.Logic.Coffee;
using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.Coffee.CoffeeTypes;
using CoffeeShop.Logic.Coffee.Condiments;
using CoffeeShop.Logic.Order.Abstract;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.LogicTests.StoresTests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CoffeeShop.LogicTests.StoresTests
{
    [TestFixture]
    public class SofiaCoffeeStore_Should
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInvalidCoffeeTypeParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            // Act && Assert
            Assert.That(() => new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInvalidCondimentParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            // Act && Assert
            Assert.That(() => new SofiaCoffeeStoreFake(null, coffeetypeStrategiesMock.Object), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldInitializeObject_WhenValidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            // Act 
            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            //Assert
            Assert.That(sofiaStore, Is.Not.Null);
            Assert.That(sofiaStore, Is.InstanceOf<ICoffeeStore>());
        }

        [Test]
        public void CreateCoffee_ShouldReturnICoffeeObject_WhenValidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();
            string coffeeType = "Espresso";
            CoffeSizeType size = CoffeSizeType.Medium;
            Func<CoffeSizeType, ICoffee> func = s => new Espresso(s);

            coffeetypeStrategiesMock.Setup(d => d.ContainsKey(coffeeType)).Returns(true);
            coffeetypeStrategiesMock.Setup(d => d[coffeeType]).Returns(func);

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);
            // Act 
            var result = sofiaStore.ExposedCreateCoffee(coffeeType, size);

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void CreateCoffee_ShouldThrowArgumentNullException_WhenInvalidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();
            string coffeeType = "Espresso";
            CoffeSizeType size = CoffeSizeType.Medium;

            coffeetypeStrategiesMock.Setup(d => d.ContainsKey(coffeeType)).Returns(false);

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            //Act & Assert
            Assert.That(() => sofiaStore.ExposedCreateCoffee(coffeeType, size), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ProcessOrder_ShouldThrowArgumentNullException_WhenInvalidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            //Act & Assert
            Assert.That(() => sofiaStore.ExposedProcessOrder(null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void ProcessOrder_ShouldCallSelectedCoffeeTypeProperty_WhenValidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();
            var processingOrderMock = new Mock<IProcessingOrder>();
            var coffeeType = "Americano";
            var coffeeSize = "Small";
            var condimentList = new List<string>();

            processingOrderMock.SetupGet(p => p.SelectedCoffeeType).Returns(coffeeType);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeSize).Returns(coffeeSize);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeCodimentsList).Returns(condimentList);

            //CoffeSizeType size = CoffeSizeType.Small;
            Func<CoffeSizeType, ICoffee> func = s => new Americano(s);
            coffeetypeStrategiesMock.Setup(d => d.ContainsKey(coffeeType)).Returns(true);
            coffeetypeStrategiesMock.Setup(d => d[coffeeType]).Returns(func);

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            // Act
            var result = sofiaStore.ExposedProcessOrder(processingOrderMock.Object);

            // Assert
            processingOrderMock.Verify(p => p.SelectedCoffeeType, Times.Once());
        }

        [Test]
        public void ProcessOrder_ShouldCallSelectedCoffeeSizeProperty_WhenValidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();
            var processingOrderMock = new Mock<IProcessingOrder>();
            var coffeeType = "Americano";
            var coffeeSize = "Small";
            var condimentList = new List<string>();

            processingOrderMock.SetupGet(p => p.SelectedCoffeeType).Returns(coffeeType);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeSize).Returns(coffeeSize);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeCodimentsList).Returns(condimentList);

            //CoffeSizeType size = CoffeSizeType.Small;
            Func<CoffeSizeType, ICoffee> func = s => new Americano(s);
            coffeetypeStrategiesMock.Setup(d => d.ContainsKey(coffeeType)).Returns(true);
            coffeetypeStrategiesMock.Setup(d => d[coffeeType]).Returns(func);

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            // Act
            var result = sofiaStore.ExposedProcessOrder(processingOrderMock.Object);

            // Assert
            processingOrderMock.Verify(p => p.SelectedCoffeeSize, Times.Once());
        }

        [Test]
        public void ProcessOrder_ShouldThrowArgumentException_WhenCantCastToEnum()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();
            var processingOrderMock = new Mock<IProcessingOrder>();
            var coffeeType = "Americano";
            var coffeeSize = "CantCastToEnum";
            var condimentList = new List<string>();

            processingOrderMock.SetupGet(p => p.SelectedCoffeeType).Returns(coffeeType);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeSize).Returns(coffeeSize);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeCodimentsList).Returns(condimentList);

            Func<CoffeSizeType, ICoffee> func = s => new Americano(s);

            coffeetypeStrategiesMock.Setup(d => d.ContainsKey(coffeeType)).Returns(true);
            coffeetypeStrategiesMock.Setup(d => d[coffeeType]).Returns(func);

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            // Act & Assert
            Assert.That(() => sofiaStore.ExposedProcessOrder(processingOrderMock.Object), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void ProcessOrder_DecorateCoffeeClassWithCondiments_WhenValidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();
            var processingOrderMock = new Mock<IProcessingOrder>();
            var coffeeType = "Americano";
            var coffeeSize = "Small";
            var condimentList = new List<string>() { "Milk", "Chocolate" };

            processingOrderMock.SetupGet(p => p.SelectedCoffeeType).Returns(coffeeType);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeSize).Returns(coffeeSize);
            processingOrderMock.SetupGet(p => p.SelectedCoffeeCodimentsList).Returns(condimentList);

            //CoffeSizeType size = CoffeSizeType.Small;
            Func<CoffeSizeType, ICoffee> func = s => new Americano(s);
            Func<ICoffee, ICoffee> funcMilk = c => new Milk(c);
            Func<ICoffee, ICoffee> funcChocolate = c => new Chocolate(c);

            coffeetypeStrategiesMock.Setup(d => d.ContainsKey(coffeeType)).Returns(true);
            coffeetypeStrategiesMock.Setup(d => d[coffeeType]).Returns(func);
            condimentsStrategiesMock.Setup(d => d.ContainsKey(It.IsIn<string>(condimentList))).Returns(true);
            condimentsStrategiesMock.Setup(d => d[condimentList[0]]).Returns(funcMilk).Verifiable();
            condimentsStrategiesMock.Setup(d => d[condimentList[1]]).Returns(funcChocolate).Verifiable();

            var sofiaStore = new SofiaCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            // Act
            var result = sofiaStore.ExposedProcessOrder(processingOrderMock.Object);

            // Assert
            Mock.Verify(new Mock[] { condimentsStrategiesMock });
            Assert.That(result.FullDescription, Contains.Substring(condimentList[0]).And.Contains(condimentList[1]));
            Assert.That(result, Is.InstanceOf<ICoffee>());
        }
    }
}