using CoffeeShop.WebUI.ViewModels.ShoppingCart.Abstract;

namespace CoffeeShop.WebUI.ViewModels.ShoppingCart
{
    public class ShoppingCartRemoveViewModel : IShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public string DeleteId { get; set; }
    }
}