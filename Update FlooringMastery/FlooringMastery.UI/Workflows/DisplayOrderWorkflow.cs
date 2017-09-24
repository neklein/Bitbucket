using FlooringMastery.BLL;
using FlooringMastery.BLL.Rules;
using FlooringMastery.Data;
using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            IDisplayOrder displayOrder = new DisplayOrderRules();
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = new OrderLookupResponse();

            //get list from respository
            //print list
            //get date from user
            //display the file associated with the date


            Console.Clear();

            string orderDate;
            while (true)
            {
                orderDate = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.DatePrompt);
                DateTime date = displayOrder.VerifyOrderDate(orderDate, response);
                if (!response.Success)
                {
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    orderDate = string.Format($"{date: MMddyyyy}").Trim(' ');
                    break;
                }
            }

            response = manager.LoadOrders(orderDate);


            if (response.Success)
            {

                foreach (var order in response.Orders)
                {
                    Console.WriteLine($"Order Number: {order.OrderNumber}");
                    ConsoleIO.PrintOrderListSummary(order);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("An Error occured");
                Console.WriteLine(response.Message);

            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
