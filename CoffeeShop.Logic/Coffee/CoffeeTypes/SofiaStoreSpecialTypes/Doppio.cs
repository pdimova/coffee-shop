namespace CoffeeShop.Logic.Coffee.CoffeeTypes.SofiaStoreSpecialTypes
{
    using Abstract;

    public class Doppio : Coffee, ICoffee
    {
        private decimal basePrice = 2.50m;

        public Doppio(CoffeSizeType size) : base("Doppio", size)
        {
        }

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
