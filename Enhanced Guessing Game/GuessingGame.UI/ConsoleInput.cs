using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame.UI
{
   public class ConsoleInput
    {
        public static int GetGuessFromUser()
        {
            Console.Clear();
            int output;
            string input;
            bool IsInt = false;

            while (!IsInt)
            {
                Console.Write("Enter a guess between 1 and 20: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out output))
                {
                    IsInt = true;
                    return output;
                }
                else
                {
                    Console.WriteLine("That was not a valid number! Press a key..");
                    Console.ReadKey();
                    IsInt = false;
                }
            }
            return -1;
        }
    }
}
