namespace CoffeeShop.LogicTests.OrderTests
{
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
    public class Order_Should
    {
        [Test]
        public void OrderClass_ShouldImplementIOrderInterface()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.That(order, Is.InstanceOf<IOrder>());
        }

        [Test]
        public void OrderClass_DefaultCountructor_ShouldInitializeObjectCorrectly()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.That(order, Is.InstanceOf<Order>());
        }

        [Test]
        public void OrderClass_SelectedCoffeeTypeProperty_ShouldExists()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.That(order, Has.Property("SelectedCoffeeType"));
        }

        [Test]
        public void OrderClass_SelectedCoffeeTypeProperty_ShouldReturnCorrectValue()
        {
            // Arrange & Act
            var coffeeType = "Espresso";
            var order = new Order();
            order.SelectedCoffeeType = coffeeType;

            // Assert
            Assert.That(order.SelectedCoffeeType, Is.SameAs(coffeeType));
        }


        [Test]
        public void OrderClass_SelectedCoffeeSizeProperty_ShouldExists()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.That(order, Has.Property("SelectedCoffeeSize"));
        }

        [Test]
        public void OrderClass_SelectedCoffeeSizeProperty_ShouldReturnCorrectValue()
        {
            // Arrange & Act
            var coffeeSize = "Grande";
            var order = new Order();
            order.SelectedCoffeeSize = coffeeSize;

            // Assert
            Assert.That(order.SelectedCoffeeSize, Is.SameAs(coffeeSize));
        }


        [Test]
        public void OrderClass_SelectedCoffeeCodimentsListProperty_ShouldExists()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.That(order, Has.Property("SelectedCoffeeCodimentsList"));
        }

        [Test]
        public void OrderClass_SelectedCoffeeCodimentsListProperty_ShouldReturnCorrectValue()
        {
            // Arrange & Act
            var condimentsList = new List<string> { "Milk", "Honey" };
            var order = new Order();
            order.SelectedCoffeeCodimentsList = condimentsList;

            // Assert
            Assert.That(order.SelectedCoffeeCodimentsList, Is.SameAs(condimentsList));
        }
    }
}
