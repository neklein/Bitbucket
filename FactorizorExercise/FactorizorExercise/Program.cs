using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorizorExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = GetNumberFromUser();

            Calculator.PrintFactors(number);
            Calculator.IsPerfectNumber(number);
            Calculator.IsPrimeNumber(number);

            Console.WriteLine("Press any key to quit...");
            Console.ReadKey();
        }
        static int GetNumberFromUser()
        {
            string input;
            int number;
            bool isInvalid = true;

            do
            {
                Console.WriteLine("What number would you like to factor?");

                input = Console.ReadLine();

                if (int.TryParse(input, out number))
                {
                    isInvalid = false;
                    
                }
                
                else
                {
                    Console.WriteLine("That is not a valid integer");
                }
                return number;
            } while (isInvalid);
     
        }
    }

    class Calculator
    {
        /// <summary>
        /// Given a number, print the factors per the specification
        /// </summary>
        public static void PrintFactors(int number)
        {
            Console.Write("The factors of " + number + " are: ");
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Console.Write(i);
                  
                }
            }
            Console.WriteLine();

        }

        /// <summary>
        /// Given a number, print if it is perfect or not
        /// </summary>
        public static void IsPerfectNumber(int number)
        {
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            if (sum == number)
            {
                Console.WriteLine(number + " is a perfect number.");
            }
            else
            {
                Console.WriteLine(number + " is not a perfect number.");
            }
            
        }

        /// <summary>
        /// Given a number, print if it is prime or not
        /// </summary>
        public static void IsPrimeNumber(int number)
        {
            int NumOfFactors = 0;
            for (int i = 2; i < number - 1; i++)
            {
                if (number % i == 0)
                {
                    NumOfFactors += i;
                }
            }
            if (NumOfFactors > 0)
            {
                Console.WriteLine(number + " is not a prime number");

            }
            else
            {
                Console.WriteLine(number + " is a prime number");
            }


        }
    }
}
