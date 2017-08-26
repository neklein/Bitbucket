using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finding42
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute();
        }
        static void Execute()
        {
            string name;
            string[] items;
            const string answer = "42";
            bool wasFound = false;
            bool keepLooping = true;

            name = PromptForName();

            while (keepLooping)
            {
                items = PromptForList(name);

                if (items.Length > 0 && items[0].ToUpper().Equals("Q"))
                {
                    keepLooping = false;
                    break;
                }

                for (int j = 0; j < items.Length; j++)
                {
                    if (IsAnswer(items[j], answer))
                    {
                        Console.WriteLine("You have the answer as the " + (j + 1) + " item in your list.");
                        wasFound = true;
                    }
                }
                if (!wasFound)
                {
                    Console.WriteLine("You may find your answer at the restaurant at the end of the universe");
                }
                wasFound = false;
                //Console.ReadKey();

            }

        }
      static  string[] PromptForList(string UserName)
        {
            Console.WriteLine($"{UserName} please provide a list of items with commas between them (press 'q' to quit)");
            string response = Console.ReadLine();
            return response.Split(',');

        }
       static string PromptForName()
        {
            Console.WriteLine("What is your name?");
            return Console.ReadLine();
        }
       static bool IsAnswer (string value, string expected)
        {
            return value.ToUpper().Equals(expected.ToUpper());
        }
    }
}
