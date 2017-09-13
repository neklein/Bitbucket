using BirthdayTracker.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ProgramFlow birthdayFlow = new ProgramFlow(FriendListFactory.Create());
                birthdayFlow.Start();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Program is not configured correctly - contact support");
                Console.WriteLine($"Exception message: {ex.Message}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
               
            }
        }
    }
}
