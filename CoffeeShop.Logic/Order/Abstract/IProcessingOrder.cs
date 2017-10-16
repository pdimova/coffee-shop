namespace CoffeeShop.Logic.Order.Abstract
{
    using System.Collections.Generic;

    public interface IProcessingOrder
    {
        string SelectedCoffeeType { get; set; }

        string SelectedCoffeeSize { get; set; }

        ICollection<string> SelectedCoffeeCodimentsList { get; set; }
    }
}
