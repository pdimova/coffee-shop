namespace CoffeeShop.Logic.Order
{
    using Abstract;
    using Coffee.Abstract;

    public class ProcessedOrder : IProcessedOrder
    {
        public ProcessedOrder(ICoffee coffee)
        {
            if (coffee == null)
            {
                throw new System.ArgumentNullException(nameof(coffee));
            }

            this.FullDescription = coffee.FullDescription;
            this.Cost = coffee.Cost();
        }
        public string FullDescription { get; private set; }

        public decimal Cost { get; private set; }
    }
}
