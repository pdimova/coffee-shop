namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Cappuccino : Coffee, ICoffee
    {
        private decimal basePrice = 3.50m;
        private string id = "CAP";

        public Cappuccino(CoffeSizeType size) : base("Cappuccino", size)
        {
        }

        public override string Id => this.id;

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
