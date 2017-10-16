namespace CoffeeShop.Logic.Coffee.CoffeeTypes.Factory
{
    using Abstract;

    public interface ICoffeeTypeFactory
    {
        ICoffee GetAmericano(CoffeSizeType size);

        ICoffee GetCappucino(CoffeSizeType size);

        ICoffee GetEspresso(CoffeSizeType size);

        ICoffee GetLatte(CoffeSizeType size);
    }
}
