using SGBank.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class Menu
    {
        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("SG Bank Application");
            Console.WriteLine("--------------------------");
            Console.WriteLine("1. Lookup an Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");

            Console.WriteLine("\nQ to quit");
            Console.Write("\nEnter selection: ");

        }

        private static bool ProcessChoice()
        {
            string userinput = Console.ReadLine();

            switch (userinput.ToUpper())
            {
                case "1":
                    AccountLookupWorkflow lookupWorkflow = new AccountLookupWorkflow();
                    lookupWorkflow.Execute();
                    break;
                case "2":
                    DepositWorkflow depositWorkflow = new DepositWorkflow();
                    depositWorkflow.Execute();
                    break;
                case "3":
                    WithdrawalWorkflow withdrawalWorkflow = new WithdrawalWorkflow();
                    withdrawalWorkflow.Execute();
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
