namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Americano : Coffee, ICoffee
    {
        private decimal basePrice = 3.10m;

        public Americano(CoffeSizeType size) : base("Americano", size)
        {
        }

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
