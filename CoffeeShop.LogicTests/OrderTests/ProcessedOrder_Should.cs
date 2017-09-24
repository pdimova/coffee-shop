namespace CoffeeShop.LogicTests.OrderTests
{
    using Logic.Coffee.Abstract;
    using Logic.Order;
    using Logic.Order.Abstract;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class ProcessedOrder_Should
    {
        [Test]
        public void ProcessedOrderClass_ShouldImplementIOrderInterface()
        {
            // Arrange 
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var order = new ProcessedOrder(coffeeMock.Object);

            // Assert
            Assert.That(order, Is.InstanceOf<IProcessedOrder>());
        }

        [Test]
        public void ProcessedOrderClass_Countructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange 
            var coffeeMock = new Mock<ICoffee>();

            // Act
            var order = new ProcessedOrder(coffeeMock.Object);

            // Assert
            Assert.That(order, Is.InstanceOf<ProcessedOrder>());
        }

        [Test]
        public void ProcessedOrderClass_Countructor_ShouldThrowArgumentNullExceptionWhenInvalidParameterProvided()
        {
            // Arrange 
            ICoffee coffee = null;

            // Act && Assert
            Assert.That(() => new ProcessedOrder(coffee), Throws.ArgumentNullException.With.Message.Contains("coffee"));
        }

        [Test]
        public void ProcessedOrderClass_Countructor_ShouldSetFullDescriptionProperty()
        {
            // Arrange 
            var description = "Coffee Description";
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.FullDescription).Returns(description).Verifiable();

            // Act
            var order = new ProcessedOrder(coffeeMock.Object);

            // Assert
            coffeeMock.Verify(x => x.FullDescription, Times.Once);
        }

        [Test]
        public void ProcessedOrderClass_Countructor_ShouldSetCostProperty()
        {
            // Arrange 
            var cost = 4.09m;
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.Cost()).Returns(cost).Verifiable();

            // Act
            var order = new ProcessedOrder(coffeeMock.Object);

            // Assert
            coffeeMock.Verify(x => x.Cost(), Times.Once);
        }

        [Test]
        public void ProcessedOrderClass_FullDescriptionProperty_ShouldReturnCorrectValue()
        {
            // Arrange 
            var description = "Coffee Description";
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.FullDescription).Returns(description);

            // Act
            var order = new ProcessedOrder(coffeeMock.Object);

            // Assert
            Assert.That(order.FullDescription, Is.EqualTo(description));
        }

        [Test]
        public void ProcessedOrderClass_CostProperty_ShouldReturnCorrectValue()
        {
            // Arrange 
            var cost = 4.09m;
            var coffeeMock = new Mock<ICoffee>();
            coffeeMock.Setup(x => x.Cost()).Returns(cost);

            // Act
            var order = new ProcessedOrder(coffeeMock.Object);

            // Assert
            Assert.That(order.Cost, Is.EqualTo(cost));
        }
    }
}
