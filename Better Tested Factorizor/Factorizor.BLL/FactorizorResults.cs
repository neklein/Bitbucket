using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor.BLL
{
    public class FactorizorResults
    {

        public int[] PrintFactors(int number)
        {
            int Sum = 0;
            int[] Factors = new int[0];
            int[] NumFactors = new int[number];
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    Sum++;
                    NumFactors[Sum - 1] += i;

                }
            }

            Factors = new int[Sum];
            for (int i = 0; i < Sum; i++)
            {
                Factors[i] = NumFactors[i];

            }

            Console.WriteLine($"The factors of {number} are: ");
            for(int i = 0; i<Factors.Length; i++)
            {
                Console.Write($"{Factors[i]}, ");
            }

            Console.WriteLine();
            return Factors;

        }

        public int PerfectNumber(int number)
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
                Console.WriteLine($"{number} is a perfect number.");
            }
            else
            {
                Console.WriteLine($"{number} is not a perfect number.");
            }

            return sum;
        }

        public int IsPrimeNumber(int number)
        {
            int NumOfFactors = 0;
            for (int i = 2; i < number - 1; i++)
            {
                if (number % i == 0)
                    NumOfFactors ++;
            }
            if (NumOfFactors > 0)
                Console.WriteLine(number + " is not a prime number");
            else
                Console.WriteLine(number + " is a prime number");

            return NumOfFactors;
        }

    }
}
