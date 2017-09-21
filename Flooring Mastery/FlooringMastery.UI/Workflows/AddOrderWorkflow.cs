using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using FlooringMastery.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderResponse response = new OrderResponse();
            //need to create a completely new file for each date.
            Console.Clear();
            Console.WriteLine("Add an Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            ProductRepository productRepository = new ProductRepository();
            TaxRepository taxRepository = new TaxRepository();

            Order newOrder = new Order();
            newOrder.OrderTax = new Tax();
            newOrder.OrderProduct = new Products();

            Console.WriteLine("Products for sale");
            List<Products> ProductList = productRepository.DisplayProduct();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            foreach(var product in ProductList)
            {
                ConsoleIO.PrintProductList(product);

            }
            Console.WriteLine(ConsoleIO.SeparatorBar);

            Console.WriteLine("The states we service");
            List<Tax> Tax = taxRepository.DisplayTax();
            foreach(var tax in Tax)
            {
                ConsoleIO.PrintStateTaxes(tax);
            }
            Console.WriteLine(ConsoleIO.SeparatorBar);

            string customerNamePrompt = "Enter the name that you want to associate with this order: ";
            string statePrompt = "Enter the abbreviation of the state for the order: ";
            string productTypePrompt = "Enter the product that you wish to order: ";
            string areaPrompt = "In square feet, enter the amount of product that you wish to order (must be over 100): ";

            //GetDate probably needs its own method
            DateTime getDate = ConsoleIO.GetRequiredDateFromUser(ConsoleIO.DatePrompt);

            while (true)
            {
                if(DateTime.Today >= getDate)
                {
                    Console.WriteLine("The new order date must occur in the future");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    getDate = ConsoleIO.GetRequiredDateFromUser(ConsoleIO.DatePrompt);

                }
                else
                {
                    break;
                }

            }
            newOrder.OrderDate = string.Format($"{getDate: MMddyyyy}").Trim(' ');

            newOrder.CustomerName = ConsoleIO.GetRequiredStringFromUser(customerNamePrompt);

            
            newOrder.OrderTax.StateAbbreviation = ConsoleIO.GetRequiredStringFromUser(statePrompt);
            while (true)
            {
                var verifyState = from tax in Tax
                                  where tax.StateAbbreviation == newOrder.OrderTax.StateAbbreviation
                                  select new
                                  {
                                      StateName = tax.StateName,
                                      TaxRate = tax.TaxRate
                                  };
                                    
                if (!verifyState.Any())
                {
                    Console.WriteLine("That is not a state we service.");
                    newOrder.OrderTax.StateAbbreviation = ConsoleIO.GetRequiredStringFromUser(statePrompt);
                }
                else
                {
                    foreach(var tax in verifyState)
                    {
                        newOrder.OrderTax.TaxRate = tax.TaxRate;
                        newOrder.OrderTax.StateName = tax.StateName;
                        Console.WriteLine($"You have selected {tax.StateName}");
                        break;

                    }
                    break;
                }
            }

            newOrder.OrderProduct.ProductType = ConsoleIO.GetRequiredStringFromUser(productTypePrompt);
            while (true)
            {
                var verifyProduct = from product in ProductList
                                   where product.ProductType == newOrder.OrderProduct.ProductType
                                   select new
                                   {
                                       ProductType = product.ProductType,
                                       CostPerSquareFoot = product.CostPerSquareFoot,
                                       LaborCostPerSquareFoot = product.LaborCostPerSquareFoot
                                   };
                if (!verifyProduct.Any())
                {
                    Console.WriteLine("That is not a product we stock.");
                    newOrder.OrderProduct.ProductType = ConsoleIO.GetRequiredStringFromUser(productTypePrompt);
                }
                else
                {
                    foreach(var product in verifyProduct)
                    {
                        newOrder.OrderProduct.CostPerSquareFoot = product.CostPerSquareFoot;
                        newOrder.OrderProduct.LaborCostPerSquareFoot = product.LaborCostPerSquareFoot;
                        Console.WriteLine($"You have selected {product.ProductType}");

                    }
                    break;
                }
            }

            newOrder.Area = ConsoleIO.GetRequiredDecimalFromUser(areaPrompt);

            newOrder.MaterialCost = response.MaterialCost(newOrder.Area, newOrder.OrderProduct.CostPerSquareFoot);
            newOrder.LaborCost = response.LaborCost(newOrder.Area, newOrder.OrderProduct.LaborCostPerSquareFoot);
            newOrder.Tax = response.Tax(newOrder.MaterialCost, newOrder.LaborCost, newOrder.OrderTax.TaxRate);
            newOrder.Total = response.Total(newOrder.MaterialCost, newOrder.LaborCost, newOrder.Tax);
            Console.WriteLine(ConsoleIO.SeparatorBar);

            Console.Clear();
            ConsoleIO.PrintOrderListSummary(newOrder);

            Console.WriteLine();
            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
                ProductionFlooringRepository rep = new ProductionFlooringRepository();
                rep.AddOrder(newOrder);
                Console.WriteLine("The order is placed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("The order is cancelled!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

        }

    }
}
