using CoffeeShop.Logic.Cart.Abstract;
using System.Collections.Generic;

namespace CoffeeShop.WebUI.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ICart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}