using CoffeeShop.Logic.Cart.Abstract;
using System.Collections.Generic;

namespace CoffeeShop.WebUI.ViewModels.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public virtual IEnumerable<ICart> CartItems { get; set; }
        public virtual decimal CartTotal { get; set; }
    }
}