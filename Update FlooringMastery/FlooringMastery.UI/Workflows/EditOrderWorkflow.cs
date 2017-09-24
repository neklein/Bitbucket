using FlooringMastery.BLL;
using FlooringMastery.BLL.Rules;
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
    public class EditOrderWorkflow
    {
        public void Execute()
        {

            IEditOrder editOrder = new EditOrderRules();
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

                DateTime date = editOrder.VerifyOrderDate(getDate, response);
                if (!response.Success)
                {
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
                        foreach(var orderPiece in particularOrder)
                        {
                            newOrder = orderPiece;
                            response.Success = true;
                        }
                        ConsoleIO.PrintOrderListSummary(newOrder);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();

                        break;
                    }
                }

            }
            else
            {
                Console.WriteLine("An Error occured");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();

            }

            while (response.Success)
            {
                Console.WriteLine("If you do not wish to change the Customer Name, State, Product Type," +
                    " or Area, then just re-type the same information again.");
                string newName = ConsoleIO.GetRequiredStringFromUser($"Edit Customer Name({newOrder.CustomerName}): ");
                newOrder.CustomerName = newName;
                Console.WriteLine($"The Customer Name is now {newName}.");


                while (true)
                {
                    Console.Clear();

                    Console.WriteLine(ConsoleIO.SeparatorBar);

                    Console.WriteLine("The states we service");
                    TaxRepository taxRepository = new TaxRepository();
                    List<Tax> Tax = taxRepository.DisplayTax();
                    Console.WriteLine(ConsoleIO.SeparatorBar);

                    Console.WriteLine("{0, -15}{1, 10}", "Abbreviation", "State Tax Rate");
                    foreach (var tax in Tax)
                    {
                        ConsoleIO.PrintStateTaxes(tax);
                    }
                    Console.WriteLine(ConsoleIO.SeparatorBar);

                    string newState = ConsoleIO.GetRequiredStringFromUser($"Edit Customer State({newOrder.OrderTax.StateAbbreviation}): ");
                    editOrder.VerifyOrderState(newOrder, newState, response);
                    if (response.Success == false)
                    {
                        Console.WriteLine(response.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        newOrder.OrderTax.StateAbbreviation = newState;
                        break;
                    }

                }

                while (true)
                {
                    Console.Clear();

                    ProductRepository productRepository = new ProductRepository();
                    Console.WriteLine("Products for sale");
                    List<Products> ProductList = productRepository.DisplayProduct();
                    Console.WriteLine(ConsoleIO.SeparatorBar);
                    Console.WriteLine("{0, -30}{1,-25}{2,5}", "Product Type", "Cost Per Square Feet", "Labor Cost Per Square Feet");
                    foreach (var product in ProductList)
                    {
                        ConsoleIO.PrintProductList(product);

                    }
                    Console.WriteLine(ConsoleIO.SeparatorBar);

                    string orderProductType = ConsoleIO.GetRequiredStringFromUser($"Edit Order Product({newOrder.OrderProduct.ProductType}): ");
                    editOrder.VerifyProduct(newOrder, orderProductType, response);
                    if (response.Success == false)
                    {
                        Console.WriteLine(response.Message);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();

                    }
                    else
                    {
                        newOrder.OrderProduct.ProductType = orderProductType;
                        break;
                    }

                }

                while (true)
                {
                    decimal orderArea = ConsoleIO.GetRequiredDecimalFromUser($"Edit Product Area({newOrder.Area}): ");
                    newOrder.Area = orderArea;
                    editOrder.VerifyArea(newOrder, response);
                    if (response.Success == false)
                    {
                        Console.WriteLine(response.Message);
                    }
                    else break;
                }

                editOrder.EditOrder(response, newOrder);
                ConsoleIO.PrintOrderListSummary(newOrder);

                string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to edit Order Number: {newOrder.OrderNumber}?");

                if (answer == "Y")
                {
                    manager.EditOrder(newOrder);
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
                break;
            }

        }
    }
}
