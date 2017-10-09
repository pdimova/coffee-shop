using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Data.Models
{
    public class Cart
    {
        public int CartId { get; set; }

        public string ShoppingCartId { get; set; }
        public string CoffeeId { get; set; }
        public string CoffeeDescription { get; set; }
        public decimal CoffeeCost { get; set; }
        public int Count { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsCheckedOut { get; set; }


        public DateTime DateCreated { get; set; }
    }
}
