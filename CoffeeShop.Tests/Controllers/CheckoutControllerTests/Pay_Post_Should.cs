using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.Checkout.Abstract;
using CoffeeShop.WebUI.ViewModels.Checkout.Factory;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.CheckoutControllerTests
{
    [TestFixture]
    public class Pay_Post_Should
    {
        [Test]
        public void ReturnView_WhenModelIsNotValid()
        {
            // Arrange
            Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
            Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
            Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();
            Mock<IPaymentAddressViewModelFactory> paymentAddressViewModelFactoryMock = new Mock<IPaymentAddressViewModelFactory>();

            Mock<IPaymentAddressViewModel> paymentAddressViewModelMock = new Mock<IPaymentAddressViewModel>();
            paymentAddressViewModelMock.SetupAllProperties();

            FormCollection fakeForm = new FormCollection();
            fakeForm.Add("Address", null);
            fakeForm.Add("Details", null);
            fakeForm.Add("Email", null);
            fakeForm.Add("FirstName", null);
            fakeForm.Add("LastName", null);
            fakeForm.Add("Phone", null);
            fakeForm.Add("PostalCode", null);

            CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object, paymentAddressViewModelFactoryMock.Object);
            checkoutController.SetFakeControllerContext();
            checkoutController.ValueProvider = fakeForm.ToValueProvider();

            //Act
            var result = checkoutController.Pay(paymentAddressViewModelMock.Object);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
        }
    }
}
