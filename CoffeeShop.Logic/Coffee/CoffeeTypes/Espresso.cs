namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Espresso : Coffee, ICoffee
    {
        private decimal basePrice = 2.00m;
        private string id = "ESP";

        public Espresso(CoffeSizeType size) : base("Espresso", size)
        {
        }

        public override string Id => this.id;

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
