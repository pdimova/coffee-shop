namespace CoffeeShop.LogicTests.CoffeeTests.CoffeeCondimentTests
{
    using CoffeeShop.Logic.Coffee.Condiments;
    using Logic.Coffee.Abstract;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class Caramel_Should
    {
        [Test]
        public void CaramelClass_ShouldImplementICoffeeInterface()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var obj = new Caramel(coffeeMock.Object);

            // Assert
            Assert.That(obj, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void CaramelClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var obj = new Caramel(coffeeMock.Object);

            // Assert
            Assert.That(obj, Is.InstanceOf<Caramel>());
        }

        [Test]
        public void CaramelClass_Countructor_ShouldThrowArgumentNullExceptionWhenNoParameterIsProvided()
        {
            // Arrange
            ICoffee coffee = null;

            // Act & Assert
            Assert.That(() => new Caramel(coffee), Throws.ArgumentNullException.With.Message.Contains("coffee"));
        }

        [Test]
        public void CaramelClass_FullDescriptionProperty_ShouldExists()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var obj = new Caramel(coffeeMock.Object);

            // Assert
            Assert.That(obj, Has.Property("FullDescription"));
        }

        [Test]
        public void CaramelClass_FullDescriptionProperty_ShouldReturnCorrectFullDescription()
        {
            // Arrange
            var coffeeDescription = "Coffee Full Description";
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.FullDescription).Returns(coffeeDescription);

            var condimentDescription = "Caramel";
            var expectedFullDescription = coffeeDescription + " " + condimentDescription;
            // Act
            var obj = new Caramel(coffeeMock.Object);

            // Assert
            Assert.That(obj.FullDescription, Is.EqualTo(expectedFullDescription));
        }

        [Test]
        public void CaramelClass_CostMethod_ShouldReturnCorrectPrice()
        {
            // Arrange
            var coffeePrice = 2.00m;
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.Cost()).Returns(coffeePrice);

            var condimentPrice = 0.70m;
            var expectedCost = coffeePrice + condimentPrice;

            // Act
            var obj = new Caramel(coffeeMock.Object);

            // Assert
            Assert.That(obj.Cost(), Is.EqualTo(expectedCost));
        }

        [Test]
        public void CaramelClass_IdProperty_ShouldReturnCorrectId()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(p => p.Id).Returns("Test");
            var expectedId = "CA1";

            // Act
            var obj = new Caramel(coffeeMock.Object);

            // Assert
            Assert.That(obj, Has.Property("Id").Contains(expectedId));
        }
    }
}
