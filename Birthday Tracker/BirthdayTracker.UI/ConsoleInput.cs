using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.UI
{
    public class ConsoleInput
    {
        public static string KeyToContinue(string message)
        {
            Console.WriteLine(message);
           return Console.ReadKey().KeyChar.ToString();
        }

        public static DateTime AskForBirthday()
        {
            Console.WriteLine("Please enter the birthday");
            DateTime input;
            string fromUser = Console.ReadLine();

            while(!DateTime.TryParse(fromUser, out input))
            {
                Console.WriteLine("That is not a valid birthday. Please try again.");
                fromUser = Console.ReadLine();
            }

            return input;
        }
    }
}
