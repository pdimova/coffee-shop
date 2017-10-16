namespace CoffeeShop.LogicTests.OrderTests
{
    using Logic.Order;
    using Logic.Order.Abstract;
    using NUnit.Framework;
    using System;

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
            Assert.That(order, Is.Not.Null);
        }

        [Test]
        public void OrderClass_AllProperties_ShouldExists()
        {
            // Arrange & Act
            var order = new Order();

            // Assert
            Assert.That(order, Has.Property("OrderId"));
            Assert.That(order, Has.Property("Username"));
            Assert.That(order, Has.Property("OrderDate"));
            Assert.That(order, Has.Property("FirstName"));
            Assert.That(order, Has.Property("LastName"));
            Assert.That(order, Has.Property("Address"));
            Assert.That(order, Has.Property("City"));
            Assert.That(order, Has.Property("PostalCode"));
            Assert.That(order, Has.Property("Phone"));
            Assert.That(order, Has.Property("Email"));
            Assert.That(order, Has.Property("Details"));
        }

        [Test]
        public void OrderClass_OrderIdProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var id = 1;

            // Act
            order.OrderId = id;

            // Assert
            Assert.That(order.OrderId, Is.EqualTo(id));
        }

        [Test]
        public void OrderClass_UsernameProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var username = "test";

            // Act
            order.Username = username;

            // Assert
            Assert.That(order.Username, Is.SameAs(username));
        }

        [Test]
        public void OrderClass_OrderDateProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var date = DateTime.Now;

            // Act
            order.OrderDate = date;

            // Assert
            Assert.That(order.OrderDate, Is.EqualTo(date));
        }

        [Test]
        public void OrderClass_FirstNameProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var name = "test";

            // Act
            order.FirstName = name;

            // Assert
            Assert.That(order.FirstName, Is.SameAs(name));
        }

        [Test]
        public void OrderClass_LastNameProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var name = "test";

            // Act
            order.LastName = name;

            // Assert
            Assert.That(order.LastName, Is.SameAs(name));
        }

        [Test]
        public void OrderClass_AddressProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var address = "Bulgaria Sofia";

            // Act
            order.Address = address;

            // Assert
            Assert.That(order.Address, Is.SameAs(address));
        }

        [Test]
        public void OrderClass_CityProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var city = "Sofia";

            // Act
            order.City = city;

            // Assert
            Assert.That(order.City, Is.SameAs(city));
        }

        [Test]
        public void OrderClass_PostalCodeProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var postalcode = "1712";

            // Act
            order.PostalCode = postalcode;

            // Assert
            Assert.That(order.PostalCode, Is.SameAs(postalcode));
        }

        [Test]
        public void OrderClass_PhoneProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var phone = "088812345678";

            // Act
            order.Phone = phone;

            // Assert
            Assert.That(order.Phone, Is.SameAs(phone));
        }

        [Test]
        public void OrderClass_EmailProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var mail = "test@testttt.bg";

            // Act
            order.Email = mail;

            // Assert
            Assert.That(order.Email, Is.SameAs(mail));
        }

        [Test]
        public void OrderClass_DetailsProperty_ShouldReturnCorrectValue()
        {
            // Arrange
            var order = new Order();
            var details = "other info";

            // Act
            order.Details = details;

            // Assert
            Assert.That(order.Details, Is.SameAs(details));
        }
    }
}