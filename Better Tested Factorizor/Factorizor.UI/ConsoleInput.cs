using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factorizor.BLL;

namespace Factorizor.UI
{
    public class ConsoleInput
    {
        public static int GetIntFromUser()
        {
            Console.Clear();
            int output;
            string input;
            bool IsInt = false;

            while (!IsInt)
            {
                Console.WriteLine("Enter a positive integer");
                input = Console.ReadLine();
                if (int.TryParse(input, out output))
                {
                    IsInt = true;
                    return output;
                }
                else
                {
                    Console.WriteLine("That is not a positive integer! Press any key...");
                    Console.ReadKey();
                    IsInt = false;
                }

            }
            return -1;
        }

    }
}
