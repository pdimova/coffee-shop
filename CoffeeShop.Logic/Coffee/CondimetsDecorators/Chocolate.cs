namespace CoffeeShop.Logic.Coffee.Condimets
{
    using System;
    using Abstract;

    public class Chocolate : ICoffee
    {
        private decimal basePrice = 0.95m;
        private string condimentDescription = "Chocolate";
        private ICoffee coffee;

        public Chocolate(ICoffee coffee)
        {
            if (coffee == null)
            {
                throw new ArgumentNullException(nameof(coffee));
            }

            this.coffee = coffee;
        }

        public string FullDescription
        {
            get { return this.coffee.FullDescription + " " + condimentDescription; }
        }

        public decimal Cost()
        {
            return this.basePrice + this.coffee.Cost();
        }
    }
}
