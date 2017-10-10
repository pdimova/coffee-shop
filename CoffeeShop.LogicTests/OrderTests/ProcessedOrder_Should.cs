namespace CoffeeShop.LogicTests.OrderTests
{
    using Logic.Order;
    using Logic.Order.Abstract;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public class ProcessingOrder_Should
    {
        [Test]
        public void ProcessingOrderClass_ShouldImplementIProcessingOrderInterface()
        {
            // Arrange & Act
            var processingOrder = new ProcessingOrder();

            // Assert
            Assert.That(processingOrder, Is.InstanceOf<IProcessingOrder>());
        }

        [Test]
        public void ProcessingOrderClass_DefaultCountructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange & Act
            var processingOrder = new ProcessingOrder();

            // Assert
            Assert.That(processingOrder, Is.Not.Null);
        }

        [Test]
        public void ProcessingOrderClass_AllProperties_ShouldExists()
        {
            // Arrange & Act
            var processingOrder = new ProcessingOrder();

            // Assert
            Assert.That(processingOrder, Has.Property("SelectedCoffeeType"));
            Assert.That(processingOrder, Has.Property("SelectedCoffeeSize"));
            Assert.That(processingOrder, Has.Property("SelectedCoffeeCodimentsList"));
        }

        [Test]
        public void ProcessingOrderClass_SelectedCoffeeTypeProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var coffeeType = "Espresso";
            var processingOrder = new ProcessingOrder();

            // Act
            processingOrder.SelectedCoffeeType = coffeeType;

            // Assert
            Assert.That(processingOrder.SelectedCoffeeType, Is.SameAs(coffeeType));
        }

        [Test]
        public void ProcessingOrderClass_SelectedCoffeeSizeProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var coffeeSize = "Grande";
            var processingOrder = new ProcessingOrder();

            // Act
            processingOrder.SelectedCoffeeSize = coffeeSize;

            // Assert
            Assert.That(processingOrder.SelectedCoffeeSize, Is.SameAs(coffeeSize));
        }

        [Test]
        public void ProcessingOrderClass_SelectedCoffeeCodimentsListProperty_ShouldReturnCorrectValue()
        {
            // Arrange & Act
            var condimentsList = new List<string> { "Milk", "Honey" };
            var processingOrder = new ProcessingOrder();

            // Act
            processingOrder.SelectedCoffeeCodimentsList = condimentsList;

            // Assert
            Assert.That(processingOrder.SelectedCoffeeCodimentsList, Is.SameAs(condimentsList));
        }
    }
}
