using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class Calculator
    {
        public int Add(string numbers)
        {
            int Sum = 0;
            string NumbersHolder = "";

            if (numbers == "")
                return Sum;

           else if (numbers.Contains(","))
            {
                //split and sum
                var elements = numbers.Split(',');

                for (int i = 0; i <elements.Length; i++)
                {
                    Sum += int.Parse(elements[i]);
                }
                
            }
         else  if (numbers.Length == 1)
            {
                Sum = int.Parse(numbers);
                
            }
            return Sum;
        }

    }
}
