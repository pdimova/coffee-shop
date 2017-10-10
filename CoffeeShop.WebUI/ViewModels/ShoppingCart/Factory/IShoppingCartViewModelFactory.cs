using CoffeeShop.WebUI.ViewModels.ShoppingCart.Abstract;

namespace CoffeeShop.WebUI.ViewModels.ShoppingCart.Factory
{
    public interface IShoppingCartViewModelFactory
    {
        IShoppingCartViewModel CreateShoppingCartViewModel();
        IShoppingCartRemoveViewModel CreateShoppingCartRemoveViewModel();
    }
}