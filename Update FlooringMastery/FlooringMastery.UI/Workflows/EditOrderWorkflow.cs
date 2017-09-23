using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class EditOrderWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Edit an Order");
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
            Order orderToEdit = new Order();
            orderToEdit.OrderTax = new Tax();
            orderToEdit.OrderProduct = new Products();
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
                    orderToEdit = confirmOrderNumber;
                    break;
                }
            }

            Console.WriteLine("If you do not wish to change the Customer Name, State, Product Type," +
                    " or Area, then just press Enter to leave the old value.");
            string newName = ConsoleIO.GetRequiredStringFromUser($"Edit Customer Name({orderToEdit.CustomerName}): ");
            if(newName == "")
            {
                Console.WriteLine($"The Customer Name is still {orderToEdit.CustomerName}.");
            }
            else
            {
                orderToEdit.CustomerName = newName;
                Console.WriteLine($"The Customer Name is now {newName}.");

            }
            string newState = ConsoleIO.GetRequiredStringFromUser($"Edit Order State({orderToEdit.OrderTax.StateAbbreviation}): ");
            if (newState == "")
            {
                Console.WriteLine($"The Customer State is still {orderToEdit.OrderTax.StateAbbreviation}.");
            }
            else
            {
                orderToEdit.OrderTax.StateAbbreviation = newState;
                Console.WriteLine($"The Customer State is now {newState}.");

            }

            string newProductType = ConsoleIO.GetRequiredStringFromUser($"Edit Order Product Type({orderToEdit.OrderProduct.ProductType}): ");
            if (newProductType == "")
            {
                Console.WriteLine($"The Order Product Type is still {orderToEdit.OrderProduct.ProductType}.");
            }
            else
            {
                orderToEdit.OrderProduct.ProductType = newProductType;
                Console.WriteLine($"The Order Product Type is now {newProductType}.");

            }

            decimal newArea = ConsoleIO.GetRequiredDecimalFromUser($"Edit Order Area({orderToEdit.Area}) or enter the same area to keep it the same: ");
            Console.WriteLine($"The Order Area is {newArea}.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            
            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to edit {orderNumber}?");

            if (answer == "Y")
            {
                repo.EditOrder(orderToEdit, orderDate, orderNumber);
                Console.WriteLine("Order edited!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Order edit cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }

        }
    }
}
