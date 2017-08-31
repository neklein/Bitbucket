using Factorizor.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.UI
{
    public class ConsoleOutput
    {
        public static void DisplayWelcome()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Factor Calculator!\n\n");
            Console.WriteLine("press any key to begin...");
            Console.ReadKey();
        }

        public static void ConcludeOrPlayAgain()
        {
            Console.WriteLine("Would you like to play again? Press Q to quit or any other key to start again...");
            string EndorNot = Console.ReadLine();

            while (true)
            {
                if (EndorNot == "Q" || EndorNot == "q")
                {
                    Console.WriteLine("Have a nice day!");
                    break;
                }
                else if (EndorNot != "Q" && EndorNot != "q")
                {
                    DisplayWelcome();
                    break;
                }
            }
        }

    }
}
