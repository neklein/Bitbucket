using FlooringMastery.BLL.Rules;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LoadOrders(string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Orders = _orderRepository.DisplayOrders(orderDate);

            

            if(!response.Orders.Any())
            {
                response.Success = false;
                response.Message = $"{orderDate} does not have any orders.";
            }
            else
            {
                response.Success = true;

            }
            return response;
        }

        public OrderResponse AddOrder (Order order)
        {
            OrderResponse response = new OrderResponse();
            
            IAddOrder orderRule = new AddOrderRules();
            response.Order = order;
            response = orderRule.AddOrder(response.Order);
            

            if (response.Success)
            {
                _orderRepository.AddOrder(response.Order);
            }
            return response;
        }

        public void DeleteOrder(string orderDate, int orderNumber)
        {
            _orderRepository.RemoveOrder(orderDate, orderNumber);
        }
        public void EditOrder(Order order)
        {
            _orderRepository.EditOrder(order, order.OrderDate, order.OrderNumber);
        }
    }
}
