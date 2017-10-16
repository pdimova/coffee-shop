namespace CoffeeShop.Logic.Order.Factory
{
    using Abstract;
    using Coffee.Abstract;

    public interface IOrderFactory
    {
        IOrder CreateOrder();
    }
}
