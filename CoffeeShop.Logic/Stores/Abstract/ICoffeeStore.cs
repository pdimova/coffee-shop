namespace CoffeeShop.Logic.Stores.Abstract
{
    using CoffeeShop.Logic.Coffee.Abstract;
    using Order.Abstract;

    public interface ICoffeeStore
    {
        ICoffee ProcessOrder(IOrder order);
    }
}
