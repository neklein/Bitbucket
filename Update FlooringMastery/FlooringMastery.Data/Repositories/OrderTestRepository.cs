﻿using FlooringMastery.Models.Interfaces;
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

        public void AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public List<Order> DisplayOrders(string OrderDate)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Order order, string orderDate, decimal orderNumber)
        {
            throw new NotImplementedException();
        }

        public Order LoadOrder(string OrderDate)
        {
            return _order;
        }

        public void RemoveOrder(string orderDate, int orderNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
