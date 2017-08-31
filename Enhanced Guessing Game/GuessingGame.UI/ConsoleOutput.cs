using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the new and tested Factorizor!\n\n");
            Console.WriteLine("Press any key to begin ...");
            Console.ReadKey();

        }
        
        public static void DisplayFactorizorResults()
        {
           
        }

        private static void DisplayFactors(int[] numbers)
        {
            Console.WriteLine("The factors of your number are: ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i] + "/t");
                Console.WriteLine();
            }
        }

        private static void DisplayIsPerfect()
        {
            if (isPerfect) Console.WriteLine("Your number is perfect");
            else Console.WriteLine("Your number is not perfect.");
        }

        private static void DisplayIsPrime()
        {
            if (isPrime) Console.WriteLine("Your number is prime");
            else Console.WriteLine("Your number is not prime.");
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("That guess is invalid! Please choose a number between 1 and 20.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public static void DisplayEnd()
        {
            Console.WriteLine("Press any key...");

        }



    }
}
