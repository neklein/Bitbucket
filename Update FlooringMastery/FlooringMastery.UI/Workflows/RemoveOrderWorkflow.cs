using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class RemoveOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove an Order");
            ProductionFlooringRepository repo = new ProductionFlooringRepository();
            
            //need to use the orderDate to grab a file
            string orderDate;
            List<Order> orders;
            while (true)
            {
                string getDate = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.DatePrompt);
                orderDate = string.Format($"{getDate: MMddyyyy}").Trim(' ');
                orders = repo.DisplayOrders(orderDate);

                var confirmOrderDate = (from order in orders
                                        where order.OrderDate == orderDate
                                        select order).FirstOrDefault();
                if (confirmOrderDate == null)
                {
                    Console.WriteLine("That is not a valid order date.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else break;
            }


            int orderNumber;
            while (true)
            {
                orderNumber = ConsoleIO.GetRequiredOrderNumberFromUser(ConsoleIO.OrderNumberPrompt);
                var confirmOrderNumber = (from order in orders
                                          where order.OrderNumber == orderNumber
                                          select order).FirstOrDefault();
                if (confirmOrderNumber == null)
                {
                    Console.WriteLine("That is not a valid order number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    ConsoleIO.PrintOrderListSummary(confirmOrderNumber);
                    break;
                } 
            }


            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove {orderNumber}?");

            if(answer == "Y")
            {
                repo.DeleteOrder(orderDate, orderNumber);
                Console.WriteLine("Order deleted!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Order deletion cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }
        }
    }
}
