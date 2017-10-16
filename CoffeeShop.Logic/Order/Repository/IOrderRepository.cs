using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.Logic.Order.Abstract;

namespace CoffeeShop.Logic.Order.Repository
{
    public interface IOrderRepository
    {
        int AddOrder(IOrder order);
    }
}
