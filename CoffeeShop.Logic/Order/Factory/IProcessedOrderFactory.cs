namespace CoffeeShop.Logic.Order.Factory
{
    using Abstract;
    using Coffee.Abstract;

    public interface IProcessedOrderFactory
    {
        IProcessedOrder CreateOrder(ICoffee coffee);
    }
}
