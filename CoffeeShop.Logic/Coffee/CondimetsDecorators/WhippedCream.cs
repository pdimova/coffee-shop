namespace CoffeeShop.Logic.Coffee.Condiments
{
    using System;
    using Abstract;

    public class WhippedCream : ICoffee
    {
        private decimal basePrice = 0.85m;
        private string condimentDescription = "Whipped Cream";
        private string id = "WIC5";
        private ICoffee coffee;

        public WhippedCream(ICoffee coffee)
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

        public string Id => this.coffee.Id + this.id;

        public decimal Cost()
        {
            return this.basePrice + this.coffee.Cost();
        }
    }
}