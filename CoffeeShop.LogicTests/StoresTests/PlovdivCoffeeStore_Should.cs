using CoffeeShop.Logic.Coffee;
using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.Coffee.CoffeeTypes;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.LogicTests.StoresTests.Fakes;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CoffeeShop.LogicTests.StoresTests
{
    [TestFixture]
    public class PlovdivCoffeeStore_Should
    {
        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInvalidCoffeeTypeParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            // Act && Assert
            Assert.That(() => new PlovdivCoffeeStoreFake(condimentsStrategiesMock.Object, null), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenInvalidCondimentParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            // Act && Assert
            Assert.That(() => new PlovdivCoffeeStoreFake(null, coffeetypeStrategiesMock.Object), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_ShouldInitializeObject_WhenValidParameterPassed()
        {
            // Arange
            var condimentsStrategiesMock = new Mock<IDictionary<string, Func<ICoffee, ICoffee>>>();
            var coffeetypeStrategiesMock = new Mock<IDictionary<string, Func<CoffeSizeType, ICoffee>>>();

            // Act 
            var plovdivStore = new PlovdivCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            //Assert
            Assert.That(plovdivStore, Is.Not.Null);
            Assert.That(plovdivStore, Is.InstanceOf<ICoffeeStore>());
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

            var plovdivStore = new PlovdivCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);
            // Act 
            var result = plovdivStore.ExposedCreateCoffee(coffeeType, size);

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

            var plovdivStore = new PlovdivCoffeeStoreFake(condimentsStrategiesMock.Object, coffeetypeStrategiesMock.Object);

            //Act & Assert
            Assert.That(() => plovdivStore.ExposedCreateCoffee(coffeeType, size), Throws.InstanceOf<ArgumentNullException>());
        }
    }
}
