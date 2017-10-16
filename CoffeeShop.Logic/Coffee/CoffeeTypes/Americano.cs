namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Americano : Coffee, ICoffee
    {
        private decimal basePrice = 3.10m;
        private string id = "AM";

        public Americano(CoffeSizeType size) : base("Americano", size)
        {
        }

        public override string Id => this.id;

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
