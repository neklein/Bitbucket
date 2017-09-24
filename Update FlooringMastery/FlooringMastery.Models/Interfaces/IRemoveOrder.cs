using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IRemoveOrder
    {
        DateTime VerifyOrderDate(string dateTime, OrderLookupResponse response);
    }
}
