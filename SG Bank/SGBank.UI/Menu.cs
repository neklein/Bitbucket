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
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("SG Bank Application");
                Console.WriteLine("--------------------------");
                Console.WriteLine("1. Lookup an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userinput = Console.ReadLine();
                //add info using this example:
                //string input;

                //while (true)
                //{
                //    Console.Write("Enter your choice (R)ock, (P)aper, or (S)cissors: ");
                //    input = Console.ReadLine();

                //    switch (input.ToUpper())
                //    {
                //        case "R":
                //            return Choice.Rock;
                //        case "P":
                //            return Choice.Paper;
                //        case "S":
                //            return Choice.Scissors;
                //    }

                //    Console.WriteLine("That was not a valid choice! Try R, P, or S!");
                //    Console.WriteLine("Press any key to continue...");
                //    Console.ReadKey();
                //}

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
                        return;
                }
           
            }
        }
    }
}
