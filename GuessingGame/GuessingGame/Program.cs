using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine(name + ", you can quit at any time by pressing Q.");
            int answer;
            string input;
            int guess = 0;
            Random rng = new Random();
            answer = rng.Next(1, 20);

            while (true)
            {
                Console.WriteLine(name + ", Enter a guess between 1 and 20");
                input = Console.ReadLine();
                if (input == "Q")
                {
                    break;
                }
                if (int.TryParse(input, out guess))
                {
                    if (guess == answer)
                    {
                        Console.WriteLine(name + ", you guessed right! The answer is {0}", answer);
                        break;
                    }
                    if (guess < 1 || guess > 20)
                    {
                        Console.WriteLine(name + ", your guess should be between 1 and 20.");
                        continue;
                    }
                    if (guess > answer)
                    {
                        Console.WriteLine(name + ", Lower!");
                    }
                    if (guess < answer)
                    {
                        Console.WriteLine(name + ", Higher!");
                    }
                }
               
            }
            Console.WriteLine(name + ", you can press any key to quit");
            Console.ReadKey();
        }
    }
}
