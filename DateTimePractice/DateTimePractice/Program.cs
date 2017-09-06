using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimePractice
{
    class Program
    {
        static void Main(string[] args)
        {
            DayOfWeekAndYear();
            Console.ReadKey();
        }

        static void DifferenceOfTwoDates()
        {
            DateTime newYears = new DateTime(DateTime.Today.Year + 1, 1, 1);

            DateTime now = DateTime.Today;

            DateTime lastDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1);

            TimeSpan timeUntilNewYears = newYears.Subtract(now);
            Console.WriteLine("It is {0} days until New Years.", timeUntilNewYears.Days);
            Console.ReadKey();
        }

        static void CreateDateTimeObjects()
        {
            //current date
            DateTime currentDateTime = DateTime.Now;
            DateTime utcNow = DateTime.UtcNow;


            DateTime onlyDate = DateTime.Today;

            DateTime aDate = new DateTime();
            DateTime SpecificDate = new DateTime(2008, 6, 15, 21, 15, 17);

            string GetFromUser = Console.ReadLine();
            DateTime UserDate;

            while (true)
            {
                Console.Write("Enter a date");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out UserDate)) continue;
            }

        }

        static void DayOfWeekAndYear()
        {
            DateTime nextIndependence = new DateTime(DateTime.Today.Year + 1, 7, 4);

            switch (nextIndependence.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    Console.WriteLine("{0:d} is on the weekend", nextIndependence);
                    break;
                default: Console.WriteLine("{0:d} is on a week day", nextIndependence);
                    break;

                
            }

            Console.WriteLine("{0:d} is on the {1} day of the year.", nextIndependence, nextIndependence.DayOfYear);
        }

        static void ManipulatingDateValues()
        {
            DateTime now = DateTime.Now;

            DateTime dueDate = now.AddDays(30).AddHours(5);

            TimeSpan ts = new TimeSpan(30, 5, 0, 0);

            DateTime dueDate.Add(ts);

            DateTime pastDays = now.AddDays(-1);


        }
    }
}
