using CoffeeShop.WebUI.ViewModels.Checkout.Abstract;

namespace CoffeeShop.WebUI.ViewModels.Checkout.Factory
{
    public interface IPaymentAddressViewModelFactory
    {
        IPaymentAddressViewModel CreatePaymentAddressViewModel();
    }
}