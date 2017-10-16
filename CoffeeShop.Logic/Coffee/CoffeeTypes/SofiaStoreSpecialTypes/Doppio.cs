namespace CoffeeShop.Logic.Coffee.CoffeeTypes.SofiaStoreSpecialTypes
{
    using Abstract;

    public class Doppio : Coffee, ICoffee
    {
        private decimal basePrice = 2.50m;
        private string id = "DOP";

        public Doppio(CoffeSizeType size) : base("Doppio", size)
        {
        }

        public override string Id => this.id;

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
