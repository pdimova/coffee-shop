using CoffeeShop.Logic.Menu;
using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.LogicTests.MenuTests.FakeCommonCoffeeTypes;
using CoffeeShop.LogicTests.MenuTests.FakeCondiments;
using CoffeeShop.LogicTests.MenuTests.FakeSpecialCoffeeTypes.Plovdiv;
using CoffeeShop.LogicTests.MenuTests.FakeSpecialCoffeeTypes.Sofia;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.LogicTests.MenuTests
{

    [TestFixture]
    public class PlovdivMenuProvider_Should
    {
        [Test]
        public void Constructor_ThrowsArgumentNullException_WhenInvalidParameterPassed()
        {
            // Arrange

            var assemblyName = typeof(PlovdivMenuProvider_Should).Assembly.GetName();
            var testingNamespace = typeof(PlovdivMenuProvider_Should).Namespace;
            var condimentsNamespace = typeof(PlovdivMenuProvider_Should).Namespace;

            // Act & Assert
            Assert.That(() => new PlovdivMenuProvider(assemblyName, testingNamespace, testingNamespace, null), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new PlovdivMenuProvider(assemblyName, testingNamespace, null, condimentsNamespace), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new PlovdivMenuProvider(assemblyName, null, testingNamespace, condimentsNamespace), Throws.InstanceOf<ArgumentNullException>());
            Assert.That(() => new PlovdivMenuProvider(null, testingNamespace, testingNamespace, condimentsNamespace), Throws.InstanceOf<ArgumentNullException>());
        }

        [Test]
        public void Constructor_InitializeNewObject_WhenInvalidParameterPassed()
        {
            // Arrange
            var assemblyName = typeof(PlovdivMenuProvider_Should).Assembly.GetName();
            var testingNamespace = typeof(PlovdivMenuProvider_Should).Namespace;
            var condimentsNamespace = typeof(PlovdivMenuProvider_Should).Namespace;

            // Act
            var plovdivMenuProvider = new PlovdivMenuProvider(assemblyName, testingNamespace, testingNamespace, condimentsNamespace);

            // Assert
            Assert.That(plovdivMenuProvider, Is.Not.Null);
            Assert.That(plovdivMenuProvider, Is.InstanceOf<IMenuProvider>());
            Assert.That(plovdivMenuProvider.GetType().Name, Contains.Substring("PlovdivMenuProvider"));
        }

        [Test]
        public void GetCoffeeTypes_ReturnCollectionOfCoffeTypesNamesAsString_WhenInvalidParameterPassed()
        {
            // Arrange
            var testingAssemblyName = typeof(PlovdivMenuProvider_Should).Assembly.GetName();
            var testingCommonCoffeeNamespace = typeof(FakeEspresso).Namespace;
            var testingSpecialCoffeeNamespace = typeof(FakeRistretto).Namespace;
            var condimentsNamespace = typeof(FakeMilk).Namespace;

            var plovdivMenuProvider = new PlovdivMenuProvider(
                testingAssemblyName,
                testingCommonCoffeeNamespace,
                testingSpecialCoffeeNamespace,
                condimentsNamespace);

            // Act
            var coffeeTypesList = plovdivMenuProvider.GetCoffeeTypes();

            // Assert
            Assert.That(coffeeTypesList, Has.Member(typeof(FakeEspresso).Name));
            Assert.That(coffeeTypesList, Has.Member(typeof(FakeRistretto).Name));
        }
    }
}
