namespace CoffeeShop.Logic.Order.Factory
{
    using CoffeeShop.Logic.Order.Abstract;

    public interface IProcessingOrderFactory
    {
        IProcessingOrder CreateOrder();
    }
}
