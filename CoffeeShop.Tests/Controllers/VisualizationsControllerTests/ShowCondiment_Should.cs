using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.VisualizationsControllerTests
{
    [TestFixture]
    public class ShowCondiment_Should
    {
        [Test]
        public void ReturnPartialView()
        {
            //Arrange
            var condiment = "Milk";

            var visualizationsController = new VisualizationsController();

            //Act
            var result = visualizationsController.ShowCondiment(condiment);

            //Assert
            Assert.That(result, Is.InstanceOf<PartialViewResult>());
        }

        //[Test]
        //public void ReplaceTheUppercaseLettersWithLowercase()
        //{
        //    //Arrange
        //    var mockCondiment = new Mock<String>();

        //    var visualizationsController = new VisualizationsController();

        //    //Act
        //    var result = visualizationsController.ShowCondiment(mockCondiment.Object);

        //    //Assert
        //    mockCondiment.Verify(m => m.ToLower(), Times.Once());
        //}
    }
}
