namespace CoffeeShop.LogicTests.CoffeeTests.CoffeeTypeTests
{
    using Logic.Coffee;
    using Logic.Coffee.Abstract;
    using Logic.Coffee.CoffeeTypes;
    using NUnit.Framework;

    [TestFixture]
    public class Cappuccino_Should
    {
        [Test]
        public void CappuccinoClass_ShouldImplementICoffeeInterface()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void CappuccinoClass_ShouldInheritCoffeeAbstractClass()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Coffee>());
        }

        [Test]
        public void CappuccinoClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj, Is.InstanceOf<Cappuccino>());
        }

        [Test]
        public void CappuccinoClass_Countructor_ShouldSetDescriptionCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Cappuccino";

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedDescription));
        }

        [Test]
        public void CappuccinoClass_Countructor_ShouldSetSizeCorrectly()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedSize = coffeeSize.ToString();

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj.FullDescription, Does.Contain(expectedSize));
        }

        [Test]
        public void CappuccinoClass_FullDescriptionProperty_ShouldExists()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription"));
        }

        [Test]
        public void CappuccinoClass_FullDescriptionProperty_ShouldReturnCorrectFullDescription()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedDescription = "Cappuccino";
            var expectedSize = coffeeSize.ToString();
            var expectedFullDescription = expectedSize + " " + expectedDescription;

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("FullDescription").EqualTo(expectedFullDescription));
        }

        [TestCase(CoffeSizeType.Small)]
        [TestCase(CoffeSizeType.Medium)]
        [TestCase(CoffeSizeType.Grande)]
        public void CappuccinoClass_CostMethod_ShouldReturnCorrectPriceBasedOnCoffeSize(CoffeSizeType coffeeSize)
        {
            // Arrange
            var basePrice = 3.50m;
            var expectedCost = basePrice + (((int)coffeeSize / 100) * basePrice);

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj.Cost(), Is.EqualTo(expectedCost));
        }

        [Test]
        public void CappuccinoClass_IdProperty_ShouldReturnCorrectId()
        {
            // Arrange
            var coffeeSize = CoffeSizeType.Medium;
            var expectedId = "CAP";

            // Act
            var obj = new Cappuccino(coffeeSize);

            // Assert
            Assert.That(obj, Has.Property("Id").EqualTo(expectedId));
        }
    }
}
