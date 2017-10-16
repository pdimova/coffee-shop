using System;

namespace CoffeeShop.Logic.Cart.Abstract
{
    public interface ICart
    {

        string ShoppingCartId { get; set; }
        string CoffeeId { get; set; }
        string CoffeeDescription { get; set; }
        decimal CoffeeCost { get; set; }
        int Count { get; set; }

    }
}
