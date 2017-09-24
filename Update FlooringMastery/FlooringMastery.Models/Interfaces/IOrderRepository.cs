using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> DisplayOrders(string OrderDate);
        void AddOrder(Order order);
        void RemoveOrder(string orderDate, int orderNumber);
        void EditOrder(Order order, string orderDate, decimal orderNumber);

    }
}
