namespace CoffeeShop.Logic.Coffee.CondimetsDecorators.Factory
{
    using Abstract;

    public interface ICondimentsFactory
    {
        ICoffee GetMilk(ICoffee coffee);

        ICoffee GetChocolate(ICoffee coffee);

        ICoffee GetCaramel(ICoffee coffee);

        ICoffee GetCinnamon(ICoffee coffee);

        ICoffee GetWhippedCream(ICoffee coffee);
    }
}
