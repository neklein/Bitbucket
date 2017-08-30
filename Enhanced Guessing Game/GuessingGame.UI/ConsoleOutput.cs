using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuessingGame.BLL;

namespace GuessingGame.UI
{
    public class ConsoleOutput
    {
        public static void DisplayTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the new and tested Guessing Game!\n\n");
            Console.WriteLine("Press any key to begin ...");
            Console.ReadKey();

        }
        
        public static void DisplayguessMessage(GuessResult result)
        {
            switch (result)
            {
                case GuessResult.Invalid:
                    DisplayInvalid();
                    break;
                case GuessResult.TooLow:
                    DisplayTooLow();
                    break;
                case GuessResult.TooHigh:
                    DisplayTooHigh();
                    break;
                case GuessResult.Correct:
                    DisplayVictory();
                    break;
            }
        }

        private static void DisplayVictory()
        {
            Console.WriteLine("Congrats! You won! You chose the correct number!");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void DisplayTooHigh()
        {
            Console.WriteLine("Too high!");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void DisplayTooLow()
        {
            Console.WriteLine("Too low!");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void DisplayInvalid()
        {
            Console.WriteLine("That guess is invalid! Please choose a number between 1 and 20.");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }



    }
}
