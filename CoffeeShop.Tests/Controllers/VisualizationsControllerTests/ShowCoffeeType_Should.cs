using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.VisualizationsControllerTests
{
    [TestFixture]
    public class ShowCoffeeType_Should
    {
        [Test]
        public void ReturnPartialView()
        {
            //Arrange
            var coffeeType = "Latte";
            var visualizationsController = new VisualizationsController();

            //Act
            var result = visualizationsController.ShowCoffeeType(coffeeType);

            //Assert
            Assert.That(result, Is.InstanceOf<PartialViewResult>());
        }

        //[Test]
        //public void ReplaceTheUppercaseLettersWithLowercase()
        //{
        //    //Arrange
        //    var mockcoffeeType = new Mock<String>();
        //    var visualizationsController = new VisualizationsController();

        //    //Act
        //    var result = visualizationsController.ShowCoffeeType(mockcoffeeType.Object);

        //    //Assert
        //    mockcoffeeType.Verify(m => m.ToLower(), Times.Once());
        //}
    }
}
