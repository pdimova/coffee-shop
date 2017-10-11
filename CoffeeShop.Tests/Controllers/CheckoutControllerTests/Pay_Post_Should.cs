using CoffeeShop.Logic.Order.Factory;
using CoffeeShop.Logic.ShoppingCart.Abstract;
using CoffeeShop.WebUI;
using CoffeeShop.WebUI.Controllers;
using CoffeeShop.WebUI.ViewModels.Checkout;
using Moq;
using NUnit.Framework;
using System.Web.Mvc;

namespace CoffeeShop.Tests.Controllers.CheckoutControllerTests
{
    [TestFixture]
    public class Pay_Post_Should
    {
        //[Test]
        //public void ReturnView_WhenModelIsNotValid()
        //{
        //    // Arrange
        //    Mock<IShoppingCart> shoppingCartMock = new Mock<IShoppingCart>();
        //    Mock<IOrderFactory> orderFactoryMock = new Mock<IOrderFactory>();
        //    Mock<ICartIdentifier> cartIdentifierMock = new Mock<ICartIdentifier>();

        //    Mock<PaymentAddressViewModel> paymentAddressViewModelMock = new Mock<PaymentAddressViewModel>();
        //    paymentAddressViewModelMock.SetupAllProperties();

        //    FormCollection fakeForm = new FormCollection();
        //    fakeForm.Add("Address", null);
        //    fakeForm.Add("Details", null);
        //    fakeForm.Add("Email", null);
        //    fakeForm.Add("FirstName", null);
        //    fakeForm.Add("LastName", null);
        //    fakeForm.Add("Phone", null);
        //    fakeForm.Add("PostalCode", null);

        //    CheckoutController checkoutController = new CheckoutController(shoppingCartMock.Object, orderFactoryMock.Object, cartIdentifierMock.Object);
        //    checkoutController.SetFakeControllerContext();
        //    checkoutController.ValueProvider = fakeForm.ToValueProvider();

        //    //Act
        //    var result = checkoutController.Pay(paymentAddressViewModelMock.Object);

        //    // Assert
        //    Assert.That(result, Is.InstanceOf<ViewResult>());
        //}
    }
}
