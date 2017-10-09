using CoffeeShop.WebUI.Controllers;
using NUnit.Framework;

namespace CoffeeShop.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CreateHomeController()
        {
            // Arrange & Act
            HomeController homeController = new HomeController();

            // Assert
            Assert.That(homeController, Is.Not.Null);
        }
    }
}
