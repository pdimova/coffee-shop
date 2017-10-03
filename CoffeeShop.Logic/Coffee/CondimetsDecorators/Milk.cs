namespace CoffeeShop.Logic.Coffee.Condiments
{
    using System;
    using Abstract;

    public class Milk : ICoffee
    {
        private decimal basePrice = 0.80m;
        private string condimentDescription = "Milk";
        private string id = "MI4";
        private ICoffee coffee;

        public Milk(ICoffee coffee)
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
