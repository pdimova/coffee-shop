namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Espresso : Coffee, ICoffee
    {
        private decimal basePrice = 2.00m;

        public Espresso(CoffeSizeType size) : base("Espresso", size)
        {
        }

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
