namespace CoffeeShop.Logic.Coffee.CoffeeTypes
{
    using Abstract;

    public class Capuccino : Coffee, ICoffee
    {
        private decimal basePrice = 3.50m;

        public Capuccino(CoffeSizeType size) : base("Capuccino", size)
        {
        }

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
