namespace CoffeeShop.Logic.Coffee.CondimetsDecorators.Factory
{
    using Abstract;

    public interface ICondimentsFactory
    {
        ICoffee GetMilk(ICoffee beverage);

        ICoffee GetChocolate(ICoffee beverage);

        ICoffee GetCaramel(ICoffee beverage);

        ICoffee GetCinnamon(ICoffee beverage);

        ICoffee GetWhippedCream(ICoffee beverage);
    }
}
