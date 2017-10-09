using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.Menu.Abstract;
using CoffeeShop.Logic.Order.Abstract;
using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.Stores.Abstract;
using CoffeeShop.WebUI.Controllers;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.StoreControllerTests
{
    [TestFixture]
    public class Index_Post_Should
    {
        [Test]
        public void ReturnView_WhenModelIsNotValid()
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();
            var controllerContextMock = new Mock<ControllerContext>();

            FormCollection fakeForm = new FormCollection(); // or mock ??
            fakeForm.Add("SelectedCoffeeType", "Americano");
            fakeForm.Add("SelectedCoffeeSize", null);

            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);
            storeController.ControllerContext = controllerContextMock.Object;
            storeController.ValueProvider = fakeForm.ToValueProvider();

            //Act
            ActionResult result = storeController.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }

        [Test]
        public void CallCreateOrder_WhenModelIsValid()
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();
            var orderMock = new Mock<IProcessingOrder>();
            var coffeeMock = new Mock<ICoffee>();

            orderFactoryMock.Setup(m => m.CreateOrder()).Returns(orderMock.Object);
            storeMock.Setup(m => m.ProcessOrder(It.IsAny<IProcessingOrder>())).Returns(coffeeMock.Object);

            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);

            FormCollection fakeForm = new FormCollection(); // or mock ??
            fakeForm.Add("SelectedCoffeeType", "Americano");
            fakeForm.Add("SelectedCoffeeSize", "Small");

            storeController.ValueProvider = fakeForm.ToValueProvider();
            storeController.SetFakeControllerContext();

            //Act
            ActionResult result = storeController.Index();

            // Assert
            orderFactoryMock.Verify(m => m.CreateOrder(), Times.Once());
        }

  
        public void CallTransferDataTo_WhenModelIsValid()
        {
            
        }

        [Test]
        public void CallProcessOrder_WhenModelIsValid()
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();
            var orderMock = new Mock<IProcessingOrder>();
            var coffeeMock = new Mock<ICoffee>();

            orderFactoryMock.Setup(m => m.CreateOrder()).Returns(orderMock.Object);
            storeMock.Setup(m => m.ProcessOrder(It.IsAny<IProcessingOrder>())).Returns(coffeeMock.Object);

            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);

            FormCollection fakeForm = new FormCollection(); // or mock ??
            fakeForm.Add("SelectedCoffeeType", "Americano");
            fakeForm.Add("SelectedCoffeeSize", "Small");

            storeController.ValueProvider = fakeForm.ToValueProvider();
            storeController.SetFakeControllerContext();

            //Act
            ActionResult result = storeController.Index();

            // Assert
            storeMock.Verify(m => m.ProcessOrder(It.IsAny<IProcessingOrder>()), Times.Once());
        }

        [Test]
        public void SetTempData_WhenModelIsValid()
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();
            var orderMock = new Mock<IProcessingOrder>();
            var coffeeMock = new Mock<ICoffee>();

            orderFactoryMock.Setup(m => m.CreateOrder()).Returns(orderMock.Object);
            storeMock.Setup(m => m.ProcessOrder(It.IsAny<IProcessingOrder>())).Returns(coffeeMock.Object);

            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);

            FormCollection fakeForm = new FormCollection(); // or mock ??
            fakeForm.Add("SelectedCoffeeType", "Americano");
            fakeForm.Add("SelectedCoffeeSize", "Small");

            storeController.ValueProvider = fakeForm.ToValueProvider();
            storeController.SetFakeControllerContext();

            //Act
            ActionResult result = storeController.Index();

            // Assert
            Assert.That((ICoffee)storeController.TempData["Order"], Is.EqualTo(coffeeMock.Object));
        }

        [Test]
        public void ReturnsPartialView_WhenModelIsValid()
        {
            // Arrange
            var storeMock = new Mock<ICoffeeStore>();
            var menuProviderMock = new Mock<IMenuProvider>();
            var orderFactoryMock = new Mock<IProcessingOrderFactory>();
            var orderMock = new Mock<IProcessingOrder>();
            var coffeeMock = new Mock<ICoffee>();

            orderFactoryMock.Setup(m => m.CreateOrder()).Returns(orderMock.Object);
            storeMock.Setup(m => m.ProcessOrder(It.IsAny<IProcessingOrder>())).Returns(coffeeMock.Object);

            StoreController storeController = new StoreController(storeMock.Object, menuProviderMock.Object, orderFactoryMock.Object);

            FormCollection fakeForm = new FormCollection(); // or mock ??
            fakeForm.Add("SelectedCoffeeType", "Americano");
            fakeForm.Add("SelectedCoffeeSize", "Small");

            storeController.ValueProvider = fakeForm.ToValueProvider();
            storeController.SetFakeControllerContext();

            //Act
            ActionResult result = storeController.Index();

            // Assert
            Assert.That(result, Is.InstanceOf<PartialViewResult>());
        }
    }
}
