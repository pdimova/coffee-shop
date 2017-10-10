namespace CoffeeShop.LogicTests.CoffeeTests.CoffeeCondimentTests
{
    using CoffeeShop.Logic.Coffee.Condiments;
    using Logic.Coffee.Abstract;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class Chocolate_Should
    {
        [Test]
        public void ChocolateClass_ShouldImplementICoffeeInterface()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var obj = new Chocolate(coffeeMock.Object);

            // Assert
            Assert.That(obj, Is.InstanceOf<ICoffee>());
        }

        [Test]
        public void ChocolateClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var obj = new Chocolate(coffeeMock.Object);

            // Assert
            Assert.That(obj, Is.InstanceOf<Chocolate>());
        }

        [Test]
        public void ChocolateClass_Countructor_ShouldThrowArgumentNullExceptionWhenNoParameterIsProvided()
        {
            // Arrange
            ICoffee coffee = null;

            // Act & Assert
            Assert.That(() => new Chocolate(coffee), Throws.ArgumentNullException.With.Message.Contains("coffee"));
        }

        [Test]
        public void ChocolateClass_FullDescriptionProperty_ShouldExists()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var obj = new Chocolate(coffeeMock.Object);

            // Assert
            Assert.That(obj, Has.Property("FullDescription"));
        }

        [Test]
        public void ChocolateClass_FullDescriptionProperty_ShouldReturnCorrectFullDescription()
        {
            // Arrange
            var coffeeDescription = "Coffee Full Description";
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.FullDescription).Returns(coffeeDescription);

            var condimentDescription = "Chocolate";
            var expectedFullDescription = coffeeDescription + " " + condimentDescription;
            // Act
            var obj = new Chocolate(coffeeMock.Object);

            // Assert
            Assert.That(obj.FullDescription, Is.EqualTo(expectedFullDescription));
        }

        [Test]
        public void ChocolateClass_CostMethod_ShouldReturnCorrectPrice()
        {
            // Arrange
            var coffeePrice = 2.00m;
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.Cost()).Returns(coffeePrice);

            var condimentPrice = 0.95m;
            var expectedCost = coffeePrice + condimentPrice;

            // Act
            var obj = new Chocolate(coffeeMock.Object);

            // Assert
            Assert.That(obj.Cost(), Is.EqualTo(expectedCost));
        }

        [Test]
        public void ChocolateClass_IdProperty_ShouldReturnCorrectId()
        {
            // Arrange
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(p => p.Id).Returns("Test");
            var expectedId = "CH2";

            // Act
            var obj = new Chocolate(coffeeMock.Object);

            // Assert
            Assert.That(obj, Has.Property("Id").Contains(expectedId));
        }
    }
}
