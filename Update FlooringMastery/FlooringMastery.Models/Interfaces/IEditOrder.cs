using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IEditOrder
    {
        DateTime VerifyOrderDate(string dateTime, OrderLookupResponse response);
        OrderLookupResponse VerifyOrderState(Order order, string orderState, OrderLookupResponse response);
        OrderLookupResponse VerifyProduct(Order order, string orderProduct, OrderLookupResponse response);
        OrderLookupResponse VerifyArea(Order order, OrderLookupResponse response);
        OrderLookupResponse EditOrder(OrderLookupResponse response, Order order);


    }
}
