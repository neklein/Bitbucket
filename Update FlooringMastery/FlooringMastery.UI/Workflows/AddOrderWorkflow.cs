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
    public class AddOrderWorkflow
    {
        public void Execute()
        {
            OrderResponse response = new OrderResponse();

            IAddOrder addOrder = new AddOrderRules();
            OrderManager orderManager = OrderManagerFactory.Create();
            ProductRepository productRepository = new ProductRepository();
            TaxRepository taxRepository = new TaxRepository();

            Order newOrder = new Order();
            newOrder.OrderTax = new Tax();
            newOrder.OrderProduct = new Products();

            Console.Clear();
            Console.WriteLine("Add an Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();


            Console.WriteLine("Products for sale");
            List<Products> ProductList = productRepository.DisplayProduct();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("{0, -30}{1,-25}{2,5}", "Product Type", "Cost Per Square Feet", "Labor Cost Per Square Feet");
            foreach (var product in ProductList)
            {
                ConsoleIO.PrintProductList(product);

            }
            Console.WriteLine(ConsoleIO.SeparatorBar);

            Console.WriteLine("The states we service");
            List<Tax> Tax = taxRepository.DisplayTax();
            Console.WriteLine(ConsoleIO.SeparatorBar);

            Console.WriteLine("{0, -15}{1, 10}", "Abbreviation", "State Tax Rate");
            foreach (var tax in Tax)
            {
                ConsoleIO.PrintStateTaxes(tax);
            }
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();

            DateTime orderDate;
            while (true)
            {
                string getDate = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.DatePrompt);

                orderDate = addOrder.VerifyOrderDate(getDate, response);
                if (response.Success == false)
                {
                    Console.WriteLine(response.Message);

                }
                else
                {
                    newOrder.OrderDate = string.Format($"{orderDate: MMddyyyy}").Trim(' ');
                    break;

                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            newOrder.CustomerName = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.customerNamePrompt);

            while (true)
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);

                Console.WriteLine("The states we service");
                Console.WriteLine(ConsoleIO.SeparatorBar);

                Console.WriteLine("{0, -15}{1, 10}", "Abbreviation", "State Tax Rate");
                foreach (var tax in Tax)
                {
                    ConsoleIO.PrintStateTaxes(tax);
                }
                Console.WriteLine(ConsoleIO.SeparatorBar);


                newOrder.OrderTax.StateAbbreviation = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.statePrompt);
                addOrder.VerifyOrderState(newOrder, response);
                if (response.Success == false)
                {
                    Console.WriteLine(response.Message);
                }
                else break;

            }
            Console.Clear();
            Console.WriteLine($"The order date is: {orderDate}");
            Console.WriteLine($"The customer name is: {newOrder.CustomerName}");
            Console.WriteLine($"The order state is: {newOrder.OrderTax.StateAbbreviation}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            while (true)
            {
                Console.WriteLine("Products for sale");
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("{0, -30}{1,-25}{2,5}", "Product Type", "Cost Per Square Feet", "Labor Cost Per Square Feet");
                foreach (var product in ProductList)
                {
                    ConsoleIO.PrintProductList(product);

                }
                Console.WriteLine(ConsoleIO.SeparatorBar);

                newOrder.OrderProduct.ProductType = ConsoleIO.GetRequiredStringFromUser(ConsoleIO.productTypePrompt);
                addOrder.VerifyProduct(newOrder, response);
                if (response.Success == false)
                {
                    Console.WriteLine(response.Message);
                }
                else break;

            }

            Console.Clear();
            Console.WriteLine($"The order date is: {orderDate}");
            Console.WriteLine($"The customer name is: {newOrder.CustomerName}");
            Console.WriteLine($"The order state is: {newOrder.OrderTax.StateAbbreviation}");
            Console.WriteLine($"The order product type is: {newOrder.OrderProduct.ProductType}");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            Console.Clear();
            while (true)
            {
                newOrder.Area = ConsoleIO.GetRequiredDecimalFromUser(ConsoleIO.areaPrompt);
                addOrder.VerifyArea(newOrder, response);
                if (response.Success == false)
                {
                    Console.WriteLine(response.Message);
                }
                else break;
            }
            addOrder.AddOrder(newOrder);


            Console.WriteLine(ConsoleIO.SeparatorBar);

            Console.Clear();
            string date = newOrder.OrderDate.Substring(0, 2) + "/" + newOrder.OrderDate.Substring(2, 2) + "/" + newOrder.OrderDate.Substring(4, 4);
            Console.WriteLine("Order Date: ", date);
            ConsoleIO.PrintOrderListSummary(newOrder);

            Console.WriteLine();
            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
                Console.WriteLine("The order is placed!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                orderManager.AddOrder(newOrder);
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
