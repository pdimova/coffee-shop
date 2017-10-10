using System.Collections.Generic;
using CoffeeShop.Logic.Cart.Abstract;

namespace CoffeeShop.WebUI.ViewModels.ShoppingCart.Abstract
{
    public interface IShoppingCartViewModel
    {
        IEnumerable<ICart> CartItems { get; set; }
        decimal CartTotal { get; set; }
    }
}