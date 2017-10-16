using System;

namespace CoffeeShop.Logic.Order.Abstract
{
    public interface IOrder
    {
        int OrderId { get; set; }
        string Username { get; set; }
        DateTime OrderDate { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string PostalCode { get; set; }
        string Phone { get; set; }
        string Email { get; set; }
        string Details { get; set; }
    }
}
