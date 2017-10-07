using CoffeeShop.Logic.Order.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Data.Models;
using System.Data.Entity;
using CoffeeShop.Logic.Order.Abstract;

namespace CoffeeShop.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Order> dbSet;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = this.context.Orders;
        }

        public int AddOrder(IOrder order)
        {
            var orderToAdd = new Order();
            orderToAdd.Username = order.Username;
            orderToAdd.DateCreated = DateTime.Now;

            orderToAdd.FirstName = order.FirstName;
            orderToAdd.LastName = order.LastName;
            orderToAdd.Address = order.Address;
            orderToAdd.City = order.City;
            orderToAdd.PostalCode = order.PostalCode;
            orderToAdd.Phone = order.Phone;

            orderToAdd.Email = order.Email;
            orderToAdd.Details = order.Details;


            this.dbSet.Add(orderToAdd);
            this.context.SaveChanges();

            //return this.dbSet.Single(o => o.Username == orderToAdd.Username && o.DateCreated == o.DateCreated).OrderId;
            return orderToAdd.OrderId;
        }
    }
}
