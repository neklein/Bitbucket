using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.Repositories
{
    public class OrderTestRepository : IOrderRepository
    {
        private static Order _order = new Order
        {
            OrderTax = new Tax(),
            OrderProduct = new Products(),
            OrderNumber = 1,
            CustomerName = "Wise",
            Area = 100M,
            OrderDate = "06012013"
        };
        public Order LoadOrder(string OrderDate)
        {
            return _order;
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
