using CoffeeShop.WebUI.Controllers;
using NUnit.Framework;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.HomeControllerTests
{
    [TestFixture]
    public class Index_Should
    {
        [Test]
        public void ReturnView()
        {
            // Arrange
            HomeController homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}