namespace CoffeeShop.Logic.Order
{
    using System;
    using Abstract;

    public class Order : IOrder
    {
        public int  OrderId { get; set; }
        public string Username { get; set; }
        public DateTime OrderDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
    }
}