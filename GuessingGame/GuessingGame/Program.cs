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
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("What is your name?");
            string name = Console.ReadLine();
            Console.WriteLine(name + ", you can quit at any time by pressing Q.");
            int answer;
            string input;
            int guess = 0;
            Random rng = new Random();
            answer = rng.Next(1, 20);
            int NumGuesses = 0;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
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
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(name + ", you guessed right! The answer is {0}", answer);
                        NumGuesses++;
                        if(NumGuesses > 1)
                        {
                            Console.WriteLine(name + ", you guessed the right answer in " + NumGuesses + " attempts");
                        }
                        if (NumGuesses == 1)
                        {
                            Console.WriteLine("Wow! You got it right on the first try. Way to go, " + name + "!");
                        }
                        break;
                    }
                    if (guess < 1 || guess > 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(name + ", your guess should be between 1 and 20.");
                        continue;
                    }
                    if (guess > answer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(name + ", Lower!");
                        NumGuesses++;
                    }
                    if (guess < answer)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(name + ", Higher!");
                        NumGuesses++;
                    }
                }
               
            }
            Console.WriteLine(name + ", you can press any key to quit");
            Console.ReadKey();
        }
    }
}
