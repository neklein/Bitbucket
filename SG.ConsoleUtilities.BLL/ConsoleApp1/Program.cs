using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SG.ConsoleUtilities.BLL;

namespace SG.ConsoleUtilities
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = UserInput.GetIntFromUser("Enter your age in years: ");
            Console.WriteLine($"You entered the age: {age}.");
            Console.ReadLine();

        }
    }
}
