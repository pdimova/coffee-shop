namespace CoffeeShop.Logic.Coffee.Condimets
{
    using System;
    using Abstract;

    public class Caramel : ICoffee
    {
        private decimal basePrice = 0.70m;
        private string condimentDescription = "Caramel";
        private string id = "CA1";
        private ICoffee coffee;

        public Caramel(ICoffee coffee)
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
