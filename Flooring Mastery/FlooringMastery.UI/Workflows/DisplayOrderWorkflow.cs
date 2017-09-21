using FlooringMastery.Data;
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
    public class DisplayOrderWorkflow
    {
        public void Execute()
        {
            //get list from respository
            //print list
            //get date from user
            //display the file associated with the date
            Console.Clear();

            DateTime orderDate = ConsoleIO.GetRequiredDateFromUser(ConsoleIO.DatePrompt);
            ProductionFlooringRepository repo = new ProductionFlooringRepository();

            string getDate = string.Format($"{orderDate:MMddyyyy}").Trim(' ');
            if (File.Exists("C:\\repos\\Bitbucket\\Data\\FlooringMasteryData\\Orders_" + getDate + ".txt"))
            {
                List<Order> orders = repo.DisplayOrders(getDate);

                Console.WriteLine("Order List for a particular date");

                foreach (var order in orders)
                {
                    ConsoleIO.PrintOrderListSummary(order);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue ...");
                    Console.ReadKey();

                }

            }
            else
            {
                Console.WriteLine("There are no orders for that order date.");

                Console.WriteLine();
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();

            }

        }
    }
}
