namespace CoffeeShop.Logic.Coffee.Abstract
{
    public interface ICoffee
    {
        string FullDescription { get; }

        string Id { get; }

        decimal Cost();
    }
}