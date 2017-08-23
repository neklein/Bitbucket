using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    class Program
    {
        static void Main(string[] args)
        {
 

            //want to force user to add a valid input
            while (true)
            {
                Console.Write("Enter a number: ");
                string input = Console.ReadLine();

                int number;

                if (int.TryParse(input, out number))
                {
                    number++;
                    //why "{0}"?
                    Console.WriteLine("The number plus 1 is: {0}", number);
                    break;
                }
                else
                {
                    Console.WriteLine("That was not a valid number");
                }
            }
            

            Console.ReadLine();
            
        }
    }
}
