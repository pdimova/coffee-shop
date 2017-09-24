namespace CoffeeShop.Logic.Order.Abstract
{
    public interface IProcessedOrder
    {
        string FullDescription { get; }

        decimal Cost { get; }
    }
}
