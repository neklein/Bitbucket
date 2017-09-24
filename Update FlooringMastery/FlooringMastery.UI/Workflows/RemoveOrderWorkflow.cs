using FlooringMastery.BLL;
using FlooringMastery.BLL.Rules;
using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
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
            Console.WriteLine(ConsoleIO.SeparatorBar);

            //need to use the orderDate to grab a file
            IRemoveOrder removeOrder = new RemoveOrderRules();
            OrderManager manager = OrderManagerFactory.Create();
            OrderLookupResponse response = new OrderLookupResponse();

            Console.Clear();
            Console.WriteLine("Edit an Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            //need to use the orderDate to grab a file
            string orderDate;
            while (true)
            {
                string getDate = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.DatePrompt);

                DateTime date = removeOrder.VerifyOrderDate(getDate, response);
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

            Order newOrder = new Order();

            response = manager.LoadOrders(orderDate);
            if (response.Success)
            {
                while (true)
                {
                    newOrder.OrderNumber = ConsoleIO.GetRequiredOrderNumberFromUser("Please enter your order number: ");
                    var particularOrder = from order in response.Orders
                                          where order.OrderNumber == newOrder.OrderNumber
                                          select order;
                    if (!particularOrder.Any())
                    {
                        response.Success = false;
                        response.Message = "No order exists with that Order Number";
                        Console.WriteLine("An Error occured");
                        Console.WriteLine(response.Message);

                    }
                    else
                    {
                        foreach (var orderPiece in particularOrder)
                        {
                            newOrder = orderPiece;
                            response.Success = true;
                        }
                        break;
                    }
                }

                string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove Order Number {newOrder.OrderNumber}?");

                if (answer == "Y")
                {
                    manager.DeleteOrder(newOrder.OrderDate, newOrder.OrderNumber);
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
            else
            {
                Console.WriteLine("An Error occured");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }


        }
    }
}
