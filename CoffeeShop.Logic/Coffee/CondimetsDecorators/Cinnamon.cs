﻿namespace CoffeeShop.Logic.Coffee.Condimets
{
    using System;
    using Abstract;

    public class Cinnamon : ICoffee
    {
        private decimal basePrice = 0.05m;
        private string condimentDescription = "Cinnamon";
        private ICoffee coffee;

        public Cinnamon(ICoffee coffee)
        {
            if (coffee == null)
            {
                throw new ArgumentNullException(nameof(coffee));
            }

            this.coffee = coffee;
        }

        public string FullDescription
        {
            get { return this.coffee.FullDescription + " " + condimentDescription; }
        }

        public decimal Cost()
        {
            return this.basePrice + this.coffee.Cost();
        }
    }
}
