using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int Add (string numbers)
            {
                int SumOfNumbers = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers == "")
                    {
                        SumOfNumbers = 0;
                    }
                   if (numbers.Length == 1)
                    {
                        SumOfNumbers = int.Parse(numbers);
                    }
                   if (numbers.Length == 2)
                    {
                        string[] NewNumbers = numbers.Split(',');
                        SumOfNumbers = int.Parse(NewNumbers[0] + NewNumbers[1]);
                    }

                }
                return SumOfNumbers;
            }
        }
    }
}
