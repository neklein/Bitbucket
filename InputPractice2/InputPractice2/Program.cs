using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InputPractice2
{
    class Program
    {
        static void Main(string[] args)
        {
            int num1 = GetIntFromUser("Please provide a number: ");
            int num2 = GetIntFromUser("Please provide a second number: ");

            Console.WriteLine("The sum is: {0}", num1 + num2);

            Console.ReadLine();
        }
            static int GetIntFromUser(string prompt)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    int number;

                    if(int.TryParse(input, out number))
                    {
                        return number;
                    }
                    Console.WriteLine("That is not a valid number!");
                }
            }
        }
    }

