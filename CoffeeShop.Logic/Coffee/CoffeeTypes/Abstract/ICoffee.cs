namespace CoffeeShop.Logic.Coffee.Abstract
{
    public interface ICoffee
    {
        string FullDescription { get; }

        decimal Cost();
    }
}
