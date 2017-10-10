namespace CoffeeShop.Logic.Order
{
    using System.Collections.Generic;
    using Abstract;

    public class ProcessingOrder : IProcessingOrder
    {
        public string SelectedCoffeeType { get; set; }

        public string SelectedCoffeeSize { get; set; }

        public ICollection<string> SelectedCoffeeCodimentsList { get; set; }
    }
}