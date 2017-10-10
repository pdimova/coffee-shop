using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.WebUI.ViewModels.ShoppingCart.Abstract;
using System.Collections.Generic;

namespace CoffeeShop.WebUI.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel : IShoppingCartViewModel
    {
        public IEnumerable<ICart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}