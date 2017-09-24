namespace CoffeeShop.Logic.Coffee.CoffeeTypes.PlovdivStoreSpecialTypes
{
    using Abstract;

    public class Ristretto : Coffee, ICoffee
    {
        private decimal basePrice = 1.50m;

        public Ristretto(CoffeSizeType size) : base("Ristretto", size)
        {
        }

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
