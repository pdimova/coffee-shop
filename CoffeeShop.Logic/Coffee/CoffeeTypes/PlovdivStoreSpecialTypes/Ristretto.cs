namespace CoffeeShop.Logic.Coffee.CoffeeTypes.PlovdivStoreSpecialTypes
{
    using Abstract;

    public class Ristretto : Coffee, ICoffee
    {
        private decimal basePrice = 1.50m;
        private string id = "RIS";

        public Ristretto(CoffeSizeType size) : base("Ristretto", size)
        {
        }

        public override string Id => this.id;

        public override decimal Cost()
        {
            return this.basePrice + (base.Cost() * this.basePrice);
        }
    }
}
