namespace CoffeeShop.LogicTests.CoffeeTests.CoffeeTypeTests
{
    using Logic.Coffee;
    using Logic.Coffee.Abstract;
    using Logic.Coffee.CoffeeTypes;
    using NUnit.Framework;

    [TestFixture]
    public class Americano_Should
    {
        [Test]
        public void AmericanoClass_ShouldImplementICoffeeInterface()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void AmericanoClass_ShouldInheritCoffeeAbstractClass()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Coffee>());
        }

        [Test]
        public void AmericanoClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Americano>());
        }

        [Test]
        public void AmericanoClass_Countructor_ShouldSetDescriptionCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Americano";

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedDescription));
        }

        [Test]
        public void AmericanoClass_Countructor_ShouldSetSizeCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedSize = coffeeSize.ToString();

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedSize));
        }

        [Test]
        public void AmericanoClass_FullDescriptionProperty_ShouldExists()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription"));
        }

        [Test]
        public void AmericanoClass_FullDescriptionProperty_ShouldReturnCorrectFullDescription()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Americano";
            var expectedSize = coffeeSize.ToString();
            var expectedFullDescription = expectedSize + " " + expectedDescription;

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription").EqualTo(expectedFullDescription));
        }

        [TestCase(CoffeSizeType.Small)]
        [TestCase(CoffeSizeType.Medium)]
        [TestCase(CoffeSizeType.Grande)]
        public void AmericanoClass_CostMethod_ShouldReturnCorrectPriceBasedOnCoffeSize(CoffeSizeType coffeeSize)
        {
            // Arrange
            var basePrice = 3.10m;
            var expectedCost = basePrice + (((int)coffeeSize / 100) * basePrice);

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj.Cost(), Is.EqualTo(expectedCost));
        }

        [Test]
        public void AmericanoClass_IdProperty_ShouldReturnCorrectId()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedId = "AM";

            // Act
            var obj = new Americano(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("Id").EqualTo(expectedId));
        }
    }
}
