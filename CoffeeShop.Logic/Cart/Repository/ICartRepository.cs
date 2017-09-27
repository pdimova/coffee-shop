using CoffeeShop.Logic.Cart.Abstract;
using System.Collections.Generic;

namespace CoffeeShop.Logic.Cart.Repository
{
    public interface ICartRepository
    {
        bool IsCartItemAvailable(string shoppingCartId, string id);
        ICart GetCartItem(string shoppingCartId, string id);
        void Add(ICart cartItem);
        void Update(ICart cartItem);
        IEnumerable<ICart> Filter(string shoppingCartId);
    }
}
