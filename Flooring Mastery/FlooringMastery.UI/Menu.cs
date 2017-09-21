using FlooringMastery.UI.Helpers;
using FlooringMastery.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class Menu
    {

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Flooring Order System");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("1. Display Orders");
            Console.WriteLine("2. Add an Order");
            Console.WriteLine("3. Edit an Order");
            Console.WriteLine("4. Remove an Order");

            Console.WriteLine("\nQ to quit");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.Write("\nEnter selection: ");

        }

        private static bool ProcessChoice()
        {
            string userinput = Console.ReadLine();

            switch (userinput.ToUpper())
            {
                case "1":
                    DisplayOrderWorkflow lookupWorkflow = new DisplayOrderWorkflow();
                    lookupWorkflow.Execute();
                    break;
                case "2":
                    AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
                    addOrderWorkflow.Execute();
                    break;
                case "3":
                    EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
                    editOrderWorkflow.Execute();
                    break;
                case "4":
                    RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
                    removeOrderWorkflow.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice. Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }
        public static void Start()
        {
            bool keepGoing = true;
            while (keepGoing)
            {
                DisplayMenu();
                keepGoing = ProcessChoice();

            }
        }

    }
}
