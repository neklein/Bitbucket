using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IAddOrder
    {
        OrderResponse AddOrder(Order order);
        DateTime VerifyOrderDate(string dateTime, OrderResponse response);
        OrderResponse VerifyOrderState(Order order, OrderResponse response);
        OrderResponse VerifyProduct(Order order, OrderResponse response);
        OrderResponse VerifyArea(Order order, OrderResponse response);


    }
}
