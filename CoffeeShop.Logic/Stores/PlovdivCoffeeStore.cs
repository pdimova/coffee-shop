namespace CoffeeShop.Logic.Stores
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using Coffee;
    using Coffee.Abstract;
    using Coffee.CondimetsDecorators.Factory;
    using Order.Factory;

    public class PlovdivCoffeeStore : CoffeeStore
    {
        private readonly IDictionary<string, Func<CoffeSizeType, ICoffee>> strategies;

        public PlovdivCoffeeStore(
            IProcessedOrderFactory processedOrderFactory,
            IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies,
            IDictionary<string, Func<CoffeSizeType, ICoffee>> strategies)
            : base(processedOrderFactory, condimentsStrategies)
        {
            if (strategies == null)
            {
                throw new ArgumentNullException(nameof(strategies));
            }

            this.strategies = strategies;
        }

        protected override ICoffee CreateCoffee(string coffeeType, CoffeSizeType size)
        {
            if (!this.strategies.ContainsKey(coffeeType))
            {
                throw new ArgumentNullException();
            }

            return this.strategies[coffeeType](size);
        }
    }
}
