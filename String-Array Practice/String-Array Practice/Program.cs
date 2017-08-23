using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Array_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "I lik chs";
            int NumOfEs = 0;
            for (int i = 0; i < s.Length; i++)
            {
                i = s.IndexOf("e", i);
                if(i == -1)
                {
                    Console.WriteLine("There is no e");
                }
                Console.WriteLine($"I found an e at index: {i}");
                
            }
            Console.ReadKey();
        }

    }
}
