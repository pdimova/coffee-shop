using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.StoreControllerTests
{
    [TestFixture]
    public class Index_Get_Should
    {
        [TestCase("<script>Sofia</script>")]
        [TestCase("Varna")]
        public void RedirectToHomeIndex_WhenParameterIsNotValid(string parameter)
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();

            //Act
            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);
            RedirectToRouteResult redirectResult = (RedirectToRouteResult)storeController.Index(parameter);

            // Assert
            Assert.That(redirectResult.RouteValues["controller"], Is.EqualTo("Home"));
            Assert.That(redirectResult.RouteValues["action"], Is.EqualTo("Index"));

        }

        [TestCase("Sofia")]
        [TestCase("Plovdiv")]
        public void SetInputParameter_WhenParameterValid(string parameter)
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();

            //Act
            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);
            storeController.Index(parameter);

            // Assert
            Assert.That(storeController.TempData["City"], Is.EqualTo(parameter));
            Assert.That(storeController.ViewBag.City, Is.EqualTo(parameter));

        }

        [TestCase("Sofia")]
        [TestCase("Plovdiv")]
        public void ReturnView_WhenInputParametersAreValid(string parameter)
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();

            //Act
            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);
            ActionResult result = storeController.Index(parameter);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}