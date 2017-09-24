namespace CoffeeShop.Logic.Stores.Abstract
{
    using Order;
    using Order.Abstract;

    public interface ICoffeeStore
    {
        IProcessedOrder ProcessOrder(IOrder order);
    }
}
