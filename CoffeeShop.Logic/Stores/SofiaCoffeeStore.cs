namespace CoffeeShop.Logic.Stores
{
    using System;
    using System.Collections.Generic;
    using Abstract;
    using Coffee;
    using Coffee.Abstract;

    public class SofiaCoffeeStore : CoffeeStore
    {
        private readonly IDictionary<string, Func<CoffeSizeType, ICoffee>> coffeetypeStrategies;

        public SofiaCoffeeStore(
            IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies,
            IDictionary<string, Func<CoffeSizeType, ICoffee>> coffeetypeStrategies)
            : base(condimentsStrategies)
        {
            if (coffeetypeStrategies == null)
            {
                throw new ArgumentNullException(nameof(coffeetypeStrategies));
            }

            this.coffeetypeStrategies = coffeetypeStrategies;
        }

        protected override ICoffee CreateCoffee(string coffeeType, CoffeSizeType size)
        {
            if (!this.coffeetypeStrategies.ContainsKey(coffeeType))
            {
                throw new ArgumentNullException();
            }

            return this.coffeetypeStrategies[coffeeType](size);
        }
    }
}
