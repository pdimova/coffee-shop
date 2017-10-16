using CoffeeShop.Logic.Menu;
using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.LogicTests.MenuTests.FakeCommonCoffeeTypes;
using CoffeeShop.LogicTests.MenuTests.FakeCondiments;
using CoffeeShop.LogicTests.MenuTests.FakeSpecialCoffeeTypes.Sofia;
using NUnit.Framework;
using System;

namespace CoffeeShop.LogicTests.MenuTests
{
    [TestFixture]
    public class SofiaMenuProvider_Should
    {
        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenInvalidParameterPassed()
        {
            // Arrange

            var assemblyName = typeof(SofiaMenuProvider_Should).Assembly.GetName();
            var testingNamespace = typeof(SofiaMenuProvider_Should).Namespace;
            var condimentsNamespace = typeof(SofiaMenuProvider_Should).Namespace;

            // Act & Assert
            Assert.That(() => new SofiaMenuProvider(assemblyName, testingNamespace, testingNamespace, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new SofiaMenuProvider(assemblyName, testingNamespace, null, condimentsNamespace), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new SofiaMenuProvider(assemblyName, null, testingNamespace, condimentsNamespace), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new SofiaMenuProvider(null, testingNamespace, testingNamespace, condimentsNamespace), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_InitializeNewObject_WhenInvalidParameterPassed()
        {
            // Arrange
            var assemblyName = typeof(SofiaMenuProvider_Should).Assembly.GetName();
            var testingNamespace = typeof(SofiaMenuProvider_Should).Namespace;
            var condimentsNamespace = typeof(SofiaMenuProvider_Should).Namespace;

            // Act
            var sofiaMenuProvider = new SofiaMenuProvider(assemblyName, testingNamespace, testingNamespace, condimentsNamespace);

            // Assert
            Assert.That(sofiaMenuProvider, Is.Not.Null);
            Assert.That(sofiaMenuProvider, Is.InstanceOf<IMenuProvider>());
            Assert.That(sofiaMenuProvider.GetType().Name, Contains.Substring("SofiaMenuProvider"));
        }

        [Test]
        public void GetCoffeeTypes_ReturnCollectionOfCoffeTypesNamesAsString_WhenInvalidParameterPassed()
        {
            // Arrange
            var testingAssemblyName = typeof(SofiaMenuProvider_Should).Assembly.GetName();
            var testingCommonCoffeeNamespace = typeof(FakeEspresso).Namespace;
            var testingSpecialCoffeeNamespace = typeof(FakeDoppio).Namespace;
            var condimentsNamespace = typeof(FakeMilk).Namespace;

            var sofiaMenuProvider = new SofiaMenuProvider(
                testingAssemblyName,
                testingCommonCoffeeNamespace,
                testingSpecialCoffeeNamespace,
                condimentsNamespace);

            // Act
            var coffeeTypesList = sofiaMenuProvider.GetCoffeeTypes();

            // Assert
            Assert.That(coffeeTypesList, Has.Member(typeof(FakeEspresso).Name));
            Assert.That(coffeeTypesList, Has.Member(typeof(FakeDoppio).Name));
        }

        [Test]
        public void GetCoffeeSizes_ReturnCollectionOfCoffeSizesNamesAsString_WhenInvalidParameterPassed()
        {
            // Arrange
            var testingAssemblyName = typeof(SofiaMenuProvider_Should).Assembly.GetName();
            var testingCommonCoffeeNamespace = typeof(FakeEspresso).Namespace;
            var testingSpecialCoffeeNamespace = typeof(FakeDoppio).Namespace;
            var condimentsNamespace = typeof(FakeMilk).Namespace;

            var sofiaMenuProvider = new SofiaMenuProvider(
                testingAssemblyName,
                testingCommonCoffeeNamespace,
                testingSpecialCoffeeNamespace,
                condimentsNamespace);

            // Act
            var coffeeTypesList = sofiaMenuProvider.GetCoffeeSizes();

            // Assert
            Assert.That(coffeeTypesList, Has.Member("Small"));
            Assert.That(coffeeTypesList, Has.Member("Medium"));
            Assert.That(coffeeTypesList, Has.Member("Grande"));
        }

        [Test]
        public void GetCoffeeCondiments_ReturnCollectionOfCoffeCondimentNamesAsString_WhenInvalidParameterPassed()
        {
            // Arrange
            var testingAssemblyName = typeof(SofiaMenuProvider_Should).Assembly.GetName();
            var testingCommonCoffeeNamespace = typeof(FakeEspresso).Namespace;
            var testingSpecialCoffeeNamespace = typeof(FakeDoppio).Namespace;
            var condimentsNamespace = typeof(FakeMilk).Namespace;

            var sofiaMenuProvider = new SofiaMenuProvider(
                testingAssemblyName,
                testingCommonCoffeeNamespace,
                testingSpecialCoffeeNamespace,
                condimentsNamespace);

            // Act
            var coffeeTypesList = sofiaMenuProvider.GetCoffeeCondiments();

            // Assert
            Assert.That(coffeeTypesList, Has.Member(typeof(FakeMilk).Name));
        }
    }
}
