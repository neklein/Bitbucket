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
            int answer;
            string input;
            int guess;
            Random rng = new Random();
            answer = rng.Next(1, 20);
            while (true)
            {
                Console.WriteLine("Enter a guess between 1 and 20");
                input = Console.ReadLine();
                if (int.TryParse(input, out guess))
                {
                    if (guess == answer)
                    {
                        break;
                    }
                    if (guess < 1 || guess > 20)
                    {
                        Console.WriteLine("Your guess should be between 1 and 20.");
                        continue;
                    }
                    if (guess > answer)
                    {
                        Console.WriteLine("Lower!");
                    }
                    if (guess < answer)
                    {
                        Console.WriteLine("Higher!");
                    }
                }
               
            }
            Console.WriteLine("You guessed right! The answer is {0}", answer);
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
        }
    }
}
