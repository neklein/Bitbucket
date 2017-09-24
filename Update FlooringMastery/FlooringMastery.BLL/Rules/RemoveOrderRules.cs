using FlooringMastery.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL.Rules
{
    public class RemoveOrderRules : IRemoveOrder
    {
        public DateTime VerifyOrderDate(string dateTime, OrderLookupResponse response)
        {
            if (!DateTime.TryParse(dateTime, out DateTime output))
            {
                Console.WriteLine("That is not a valid date");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                response.Success = false;
            }
            else
                response.Success = true;
            return output;

        }

    }
}
