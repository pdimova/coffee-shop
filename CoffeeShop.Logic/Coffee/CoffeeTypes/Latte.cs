namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Latte : Coffee, ICoffee
    {
        private decimal basePrice = 3.00m;

        public Latte(CoffeSizeType size) : base("Latte", size)
        {
        }

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
