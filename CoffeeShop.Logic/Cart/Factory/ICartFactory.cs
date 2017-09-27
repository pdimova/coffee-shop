using CoffeeShop.Logic.Cart.Abstract;

namespace CoffeeShop.Logic.Cart.Factory
{
    public interface ICartFactory
    {
        ICart CreateCart();
    }
}
