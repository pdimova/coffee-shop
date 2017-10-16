using CoffeeShop.Logic.Cart.Abstract;
using System.Collections.Generic;

namespace CoffeeShop.Logic.Cart.Repository
{
    public interface ICartRepository
    {
        bool IsCartItemAvailable(string shoppingCartId, string id);
        ICart GetCartItemByCoffeeId(string shoppingCartId, string id);
        ICart GetCartItemByCartId(string shoppingCartId, int cartId);
        void Add(ICart cartItem);
        void Update(ICart cartItem);
        IEnumerable<ICart> Filter(string shoppingCartId);
        void Remove(ICart cartItem);
        decimal GetSum(string shoppingCartId);
        int GetCount(string shoppingCartId);
        void Migrate(string shoppingCartId, string userName);
        void CheckOutAll(string shoppingCartId);
    }
}
