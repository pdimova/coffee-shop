namespace CoffeeShop.Logic.Stores.Abstract
{
    using System;
    using Coffee;
    using Coffee.Abstract;
    using Order.Abstract;
    using Order.Factory;
    using System.Collections.Generic;

    public abstract class CoffeeStore : ICoffeeStore
    {
        private readonly IProcessedOrderFactory processedOrderFactory;
        private readonly IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies;

        public CoffeeStore(
            IProcessedOrderFactory processedOrderFactory,
            IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies)
        {
            if (condimentsStrategies == null)
            {
                throw new ArgumentNullException(nameof(condimentsStrategies));
            }

            if (processedOrderFactory == null)
            {
                throw new ArgumentNullException(nameof(processedOrderFactory));
            }

            this.processedOrderFactory = processedOrderFactory;
            this.condimentsStrategies = condimentsStrategies;
        }

        public IProcessedOrder ProcessOrder(IOrder order)
        {
            ICoffee coffee;

            var coffeeType = order.SelectedCoffeeType;

            CoffeSizeType coffeeSize;
            Enum.TryParse(order.SelectedCoffeeSize, out coffeeSize);

            coffee = this.CreateCoffee(coffeeType, coffeeSize);

            foreach (var condimentAsString in order.SelectedCoffeeCodimentsList)
            {
                if (!this.condimentsStrategies.ContainsKey(condimentAsString))
                {
                    throw new ArgumentException(condimentAsString);
                }

                coffee = this.condimentsStrategies[condimentAsString](coffee);
            }

            // Might not be so good idea to return IProcessedOrder insted of ICoffee
            var processedOrder = this.processedOrderFactory.CreateOrder(coffee);

            return processedOrder;
        }

        // abstract factory method
        protected abstract ICoffee CreateCoffee(string coffeeType, CoffeSizeType size);
    }
}
