namespace CoffeeShop.Logic.Order.Factory
{
    using CoffeeShop.Logic.Order.Abstract;

    public interface IOrderFactory
    {
        IOrder CreateOrder();
    }
}
