using CoffeeShop.Logic.Cart.Abstract;
using System;

namespace CoffeeShop.Logic.Cart
{
    public class Cart : ICart
    {
        public Cart()
        {

        }

        public string ShoppingCartId { get; set; }
        public string CoffeeId { get; set; }
        public string CoffeeDescription { get; set; }
        public decimal CoffeeCost { get; set; }
        public int Count { get; set; }

    }
}
