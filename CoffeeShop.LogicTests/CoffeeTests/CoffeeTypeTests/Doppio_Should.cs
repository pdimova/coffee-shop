namespace CoffeeShop.LogicTests.CoffeeTests.CoffeeTypeTests
{
    using Logic.Coffee;
    using Logic.Coffee.Abstract;
    using Logic.Coffee.CoffeeTypes.SofiaStoreSpecialTypes;
    using NUnit.Framework;

    [TestFixture]
    public class Doppio_Should
    {
        [Test]
        public void DoppioClass_ShouldImplementICoffeeInterface()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void DoppioClass_ShouldInheritCoffeeAbstractClass()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Coffee>());
        }

        [Test]
        public void DoppioClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Doppio>());
        }

        [Test]
        public void DoppioClass_Countructor_ShouldSetDescriptionCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Doppio";

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedDescription));
        }

        [Test]
        public void DoppioClass_Countructor_ShouldSetSizeCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedSize = coffeeSize.ToString();

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedSize));
        }

        [Test]
        public void DoppioClass_FullDescriptionProperty_ShouldExists()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription"));
        }

        [Test]
        public void DoppioClass_FullDescriptionProperty_ShouldReturnCorrectFullDescription()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Doppio";
            var expectedSize = coffeeSize.ToString();
            var expectedFullDescription = expectedSize + " " + expectedDescription;

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription").EqualTo(expectedFullDescription));
        }

        [TestCase(CoffeSizeType.Small)]
        [TestCase(CoffeSizeType.Medium)]
        [TestCase(CoffeSizeType.Grande)]
        public void DoppioClass_CostMethod_ShouldReturnCorrectPriceBasedOnCoffeSize(CoffeSizeType coffeeSize)
        {
            // Arrange
            var basePrice = 2.50m;
            var expectedCost = basePrice + (((int)coffeeSize / 100) * basePrice);

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj.Cost(), Is.EqualTo(expectedCost));
        }

        [Test]
        public void DoppioClass_IdProperty_ShouldReturnCorrectId()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedId = "DOP";

            // Act
            var obj = new Doppio(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("Id").EqualTo(expectedId));
        }
    }
}
