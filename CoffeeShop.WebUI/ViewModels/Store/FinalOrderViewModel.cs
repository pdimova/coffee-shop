namespace CoffeeShop.WebUI.ViewModels.Store
{
    using CoffeeShop.Logic.Coffee.Abstract;
    using System;

    public class FinalOrderViewModel
    {
        private ICoffee coffee;

        public FinalOrderViewModel(ICoffee coffee)
        {
            if (coffee == null)
            {
                throw new ArgumentNullException();
            }

            this.coffee = coffee;

            this.FullDescription = coffee.FullDescription;
            this.Price = coffee.Cost();
        }

        public string FullDescription { get; set; }

        public decimal Price { get; set; }
    }
}
