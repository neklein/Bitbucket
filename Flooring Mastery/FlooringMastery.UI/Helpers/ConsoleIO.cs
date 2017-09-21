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
        public const string SeparatorBar = "==============================================================";
        public const string DatePrompt = "Enter the Order Date: ";
        public const string OrderNumberPrompt = "Enter the order number for the order that you wish to edit: ";


        public static void PrintOrderListSummary(Order order)
        {
            string line = "{0, -15}{1, -15}";

            Console.WriteLine(SeparatorBar);
            Console.WriteLine(line, order.OrderNumber, order.OrderDate);
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.OrderTax.StateAbbreviation}");
            Console.WriteLine($"Product: {order.OrderProduct.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost}");
            Console.WriteLine($"Labor: {order.LaborCost}");
            Console.WriteLine($"Tax: {order.Tax}");
            Console.WriteLine($"Total: {order.Total}");
            Console.WriteLine(SeparatorBar);


        }

        public static void PrintProductList(Products products)
        {
            string line = "{0, -15}{1, -25}{2, 5}";
            Console.WriteLine(line, "Product Type", "Cost Per Square Feet", "Labor Cost Per Square Feet");

            Console.WriteLine(line, products.ProductType, products.CostPerSquareFoot, products.LaborCostPerSquareFoot);
        }

        public static void PrintStateTaxes(Tax tax)
        {
            string line = "{0, -15}{1, -15}{2, 10}";
            Console.WriteLine(line, "Abbreviation", "State Name", "State Tax Rate");
            Console.WriteLine(line, tax.StateAbbreviation, tax.StateName, tax.TaxRate);

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
                    Console.WriteLine("That is not a valid order number.");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                else
                {
                    
                    return output;

                }

            }
            
        }

        public static DateTime GetRequiredDateFromUser(string prompt)
        {
            DateTime orderDate = DateTime.Today;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime output) == false)
                {
                    Console.WriteLine("That is not a valid date");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    
                }
                else
                {
                    orderDate = output;
                    return orderDate;
                }

            }

        }

    }   
}
