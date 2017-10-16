namespace CoffeeShop.Logic.Menu.Abstract
{
    using System.Collections.Generic;

    public interface IMenuProvider
    {
        ICollection<string> GetCoffeeTypes();

        IEnumerable<string> GetCoffeeSizes();

        IEnumerable<string> GetCoffeeCondiments();
    }
}
