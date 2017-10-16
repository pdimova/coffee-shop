using CoffeeShop.Logic.Coffee;
using CoffeeShop.Logic.Coffee.Abstract;
using CoffeeShop.Logic.Order.Abstract;
using CoffeeShop.Logic.Stores;
using System;
using System.Collections.Generic;

namespace CoffeeShop.LogicTests.StoresTests.Fakes
{
    public class PlovdivCoffeeStoreFake : PlovdivCoffeeStore
    {
        public PlovdivCoffeeStoreFake(
            IDictionary<string, Func<ICoffee, ICoffee>> condimentsStrategies,
            IDictionary<string, Func<CoffeSizeType, ICoffee>> coffeetypeStrategies)
                : base(condimentsStrategies, coffeetypeStrategies)
        {
        }

        public ICoffee ExposedCreateCoffee(string coffeeType, CoffeSizeType size)
        {
            return base.CreateCoffee(coffeeType, size);
        }

        public ICoffee ExposedProcessOrder(IProcessingOrder order)
        {
            return base.ProcessOrder(order);
        }
    }
}