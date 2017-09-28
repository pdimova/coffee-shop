using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.Coffee.Abstract;
using System.Collections.Generic;

namespace CoffeeShop.Logic.ShoppingCart.Abstract
{
    public interface IShoppingCart
    {
        IShoppingCart GetShoppingCart(string id);

        void AddToCart(ICoffee orderedCofee);
        int RemoveFromCart(string coffeeId);
        IEnumerable<ICart> GetCartItems();
        decimal GetTotal();
        int GetCount();
    }
}
