namespace CoffeeShop.Logic.Stores.Abstract
{
    using System;
    using Coffee;
    using Coffee.Abstract;
    using Order.Abstract;
    using System.Collections.Generic;

    public abstract class CoffeeStore : ICoffeeStore
    {
        private readonly IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies;

        public CoffeeStore(IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies)
        {
            if (condimentsStrategies == null)
            {
                throw new ArgumentNullException(nameof(condimentsStrategies));
            }

            this.condimentsStrategies = condimentsStrategies;
        }

        public ICoffee ProcessOrder(IProcessingOrder order)
        {
            if (order == null)
            {
                throw new ArgumentNullException();
            }

            ICoffee coffee;

            var coffeeType = order.SelectedCoffeeType;

            CoffeSizeType coffeeSize;

            if (!Enum.TryParse(order.SelectedCoffeeSize, out coffeeSize))
            {
                throw new ArgumentException();
            }

            coffee = this.CreateCoffee(coffeeType, coffeeSize);

            foreach (var condimentAsString in order.SelectedCoffeeCodimentsList)
            {
                if (!this.condimentsStrategies.ContainsKey(condimentAsString))
                {
                    throw new ArgumentException(condimentAsString);
                }

                coffee = this.condimentsStrategies[condimentAsString](coffee);
            }

            return coffee;
        }

        // abstract factory method
        protected abstract ICoffee CreateCoffee(string coffeeType, CoffeSizeType size);
    }
}
