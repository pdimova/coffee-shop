using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.VisualizationsControllerTests
{

    [TestFixture]
    public class ShowCoffeeSize_Should
    {
        [Test]
        public void ReturnPartialView()
        {
            //Arrange
            var coffeeType = "Latte";
            var coffeeSize = "Small";

            var visualizationsController = new VisualizationsController();

            //Act
            var result = visualizationsController.ShowCoffeeSize(coffeeType, coffeeSize);

            //Assert
            Assert.That(result, Is.InstanceOf<PartialViewResult>());
        }

        //[Test]
        //public void ReplaceTheUppercaseLettersWithLowercase()
        //{
        //    //Arrange
        //    var mockCoffeeType = new Mock<String>();
        //    var mockCoffeeSize = new Mock<String>();

        //    var visualizationsController = new VisualizationsController();

        //    //Act
        //    var result = visualizationsController.ShowCoffeeSize(mockCoffeeType.Object, mockCoffeeSize.Object);

        //    //Assert
        //    mockCoffeeType.Verify(m => m.ToLower(), Times.Once());
        //    mockCoffeeSize.Verify(m => m.ToLower(), Times.Once());
        //}
    }
}
