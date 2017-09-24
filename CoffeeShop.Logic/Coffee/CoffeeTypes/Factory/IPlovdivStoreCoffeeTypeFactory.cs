namespace CoffeeShop.Logic.Coffee.CoffeeTypes.Factory
{
    using Abstract;

    public interface IPlovdivStoreCoffeeTypeFactory : ICoffeeTypeFactory
    {
        ICoffee GetRistretto(CoffeSizeType size);
    }
}
