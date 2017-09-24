using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Helpers
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "===============================================================================================================";
        public const string DatePrompt = "Enter the Order Date: ";
        public const string OrderNumberPrompt = "Enter the order number for the order that you wish to edit: ";
        public const string customerNamePrompt = "Enter the name that you want to associate with this order: ";
        public const string statePrompt = "Enter the abbreviation of the state for the order: ";
        public const string productTypePrompt = "Enter the product that you wish to order: ";
        public const string areaPrompt = "In square feet, enter the amount of product that you wish to order (must be over 100): ";


        public static void PrintOrderListSummary(Order order)
        {
            Console.WriteLine(SeparatorBar);
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.OrderTax.StateAbbreviation}");
            Console.WriteLine($"Product: {order.OrderProduct.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Materials: {order.MaterialCost}");
            Console.WriteLine($"Labor: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine(SeparatorBar);


        }

        public static void PrintProductList(Products products)
        {
            string line = "{0, -40}{1, -25}{2, 5}";
            Console.WriteLine(line, products.ProductType, products.CostPerSquareFoot, products.LaborCostPerSquareFoot);
        }

        public static void PrintStateTaxes(Tax tax)
        {
            string line = "{0, -15}{1, 10}";
            Console.WriteLine(line, tax.StateAbbreviation, tax.TaxRate);

        }


        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string Input = Console.ReadLine();


                if (string.IsNullOrEmpty(Input))
                {
                    Console.WriteLine("That is not a valid input.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    return Input;

                }

            }

        }

        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt + " (Y/N)? ");
                string Input = Console.ReadLine();


                if (string.IsNullOrEmpty(Input))
                {
                    Console.WriteLine("You must enter Y/N");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    if (Input != "Y" && Input != "N")
                    {
                        Console.WriteLine("You must enter Y/N");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        continue;
                    }
                    return Input;

                }

            }
        }

        public static decimal GetRequiredDecimalFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string Input = Console.ReadLine();


                if (!decimal.TryParse(Input, out decimal output))
                {
                    Console.WriteLine("That is not a valid area.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 100M)
                    {
                        Console.WriteLine("The area must be greater than 100.");
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        continue;

                    }
                    return output;

                }

            }
        }

        public static int GetRequiredOrderNumberFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string Input = Console.ReadLine();


                if (!int.TryParse(Input, out int output))
                {
                    Console.WriteLine("That is not a possible number.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    
                    return output;

                }

            }
            
        }


    }   
}
