namespace CoffeeShop.Logic.Coffee.CoffeeTypes.Factory
{
    using Abstract;

    public interface ISofiaStoreCoffeeTypeFactory : ICoffeeTypeFactory
    {
        ICoffee GetDoppio(CoffeSizeType size);
    }
}
