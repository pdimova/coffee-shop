using CoffeeShop.Logic.Cart.Abstract;
using CoffeeShop.Logic.Coffee.Abstract;
using System.Collections.Generic;
using CoffeeShop.Logic.Order.Abstract;

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
        int SaveOrder(IOrder order);
        bool ValidateOrder(int id, string name);
        void MigrateCart(string userName);
    }
}
