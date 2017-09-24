using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.Rules
{
    public class DisplayOrderRules : IDisplayOrder
    {
        public DateTime VerifyOrderDate(string dateTime, OrderLookupResponse response)
        {
            if (!DateTime.TryParse(dateTime, out DateTime output))
            {
                response.Success = false;
                Console.WriteLine("That is not a valid date");
            }
            else response.Success = true;

            return output;
        }
    }
}
