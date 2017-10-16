namespace CoffeeShop.LogicTests.CoffeeTests.CoffeeTypeTests
{
    using Logic.Coffee;
    using Logic.Coffee.Abstract;
    using Logic.Coffee.CoffeeTypes;
    using NUnit.Framework;

    [TestFixture]
    public class Espresso_Should
    {
        [Test]
        public void EspressoClass_ShouldImplementICoffeeInterface()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void EspressoClass_ShouldInheritCoffeeAbstractClass()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Coffee>());
        }

        [Test]
        public void EspressoClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Espresso>());
        }

        [Test]
        public void EspressoClass_Countructor_ShouldSetDescriptionCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Espresso";

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedDescription));
        }

        [Test]
        public void EspressoClass_Countructor_ShouldSetSizeCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedSize = coffeeSize.ToString();

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedSize));
        }

        [Test]
        public void EspressoClass_FullDescriptionProperty_ShouldExists()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription"));
        }

        [Test]
        public void EspressoClass_FullDescriptionProperty_ShouldReturnCorrectFullDescription()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Espresso";
            var expectedSize = coffeeSize.ToString();
            var expectedFullDescription = expectedSize + " " + expectedDescription;

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription").EqualTo(expectedFullDescription));
        }

        [TestCase(CoffeSizeType.Small)]
        [TestCase(CoffeSizeType.Medium)]
        [TestCase(CoffeSizeType.Grande)]
        public void EspressoClass_CostMethod_ShouldReturnCorrectPriceBasedOnCoffeSize(CoffeSizeType coffeeSize)
        {
            // Arrange
            var basePrice = 2.00m;
            var expectedCost = basePrice + (((int)coffeeSize / 100) * basePrice);

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj.Cost(), Is.EqualTo(expectedCost));
        }

        [Test]
        public void EspressoClass_IdProperty_ShouldReturnCorrectId()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedId = "ESP";

            // Act
            var obj = new Espresso(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("Id").EqualTo(expectedId));
        }
    }
}
