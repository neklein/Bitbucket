using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeLab
{
    public class DateTimeLabCode
    {
        /// <summary>
        /// Returns a DateTime object that is
        /// set to the current day's date.
        /// </summary>
        public DateTime GetTheDateToday()
        {
            Console.WriteLine(DateTime.Today);

            DateTime Today = DateTime.Today;
            return Today;
        }

        /// <summary>
        /// Returns a string that represents the date for 
        /// the month day and year passed into the method parameters 
        /// as integers. Expected Return value should be in format
        /// "12/25/15"
        /// </summary>
        public string GetShortDateStringFromParamaters(int month, int day, int year)
        {
            DateTime NeedDate = new DateTime(year, month, day);


            string DateToString = string.Format("{0:M/d/yy}", NeedDate);

            return DateToString;
        }

        /// <summary>
        /// Returns a DateTime object that is created based on
        /// a string representation provided by the user.  Should
        /// handle date formats such as "4/1/2015", "04.01.15", 
        /// "April 1, 2015", "25 Dec 2015"
        /// </summary>
        public DateTime GetDateTimeObjectFromString(string date)
        {
            string DateToString = string.Format("{0:M/d/yyyy}", date);

            DateTime GetThatDate = DateTime.Parse(DateToString);

            return GetThatDate;

        }

        /// <summary>
        /// Returns a formatted date string based on a string
        /// object passed in from the calling code.  Format should
        /// be in the form "09.02.2005 01:55 PM"
        /// </summary>
        public string GetFormatedDateString(string date)
        {
            DateTime GetDate = DateTime.Parse(date);


            string FormatedDate = string.Format("{0:MM.dd.yyyy hh:mm tt}", GetDate);

            return FormatedDate;
        }

        /// <summary>
        /// Returns a formatted date string that is six
        /// months in the future from the date passed in.
        /// The result should be formatted like "July 4, 1776"
        /// </summary>
        public string GetDateInSixMonths(string date)
        {
            DateTime NewDate = DateTime.Parse(date);

            NewDate = NewDate.AddMonths(6);

            string UpdatedDate = string.Format("{0:MMMM d, yyyy}", NewDate);

            return UpdatedDate;
        }

        /// <summary>
        /// Returns a formatted date string that is thirty
        /// days in the past from the date passed in.
        /// The result should be formatted like "January 1, 2005"
        /// </summary>
        public string GetDateThirtyDaysInPast(string date)
        {
            DateTime GettingPastDate = DateTime.Parse(date);

            GettingPastDate = GettingPastDate.AddDays(-30);

            string UpdatedDate = string.Format("{0:MMMM d, yyyy}", GettingPastDate);

            return UpdatedDate;

        }


        /// <summary>
        /// Returns an array of DateTime objects containing the next count
        /// number of wednesdays on or after the given date
        /// </summary>
        /// <param name="count">the number of wednesdays to return</param>
        /// <param name="startDate">the starting date</param>
        /// <returns>An array of date objects of size count</returns>
        public DateTime[] GetNextWednesdays(int count, string startDate)
        {
            DateTime[] Wednesdays = new DateTime[count];


            DateTime FirstWednesday = new DateTime();

            DateTime WhenDoesItStart = DateTime.Parse(startDate);

            DayOfWeek FindWednesday = WhenDoesItStart.DayOfWeek;
            switch (FindWednesday)
            {
                case DayOfWeek.Sunday:
                    FirstWednesday = WhenDoesItStart.AddDays(3);
                    break;

                case DayOfWeek.Monday:
                    FirstWednesday = WhenDoesItStart.AddDays(2);
                    break;

                case DayOfWeek.Tuesday:
                    FirstWednesday = WhenDoesItStart.AddDays(1);
                    break;

                case DayOfWeek.Wednesday:
                    FirstWednesday = WhenDoesItStart;
                    break;

                case DayOfWeek.Thursday:
                    FirstWednesday = WhenDoesItStart.AddDays(6);
                    break;

                case DayOfWeek.Friday:
                    FirstWednesday = WhenDoesItStart.AddDays(5);
                    break;

                case DayOfWeek.Saturday:
                    FirstWednesday = WhenDoesItStart.AddDays(4);
                    break;
            }

            Wednesdays[0] = FirstWednesday;
            for (int i = 1; i < Wednesdays.Length; i++)
            {
                FirstWednesday = FirstWednesday.AddDays(7);
                Wednesdays[i] = FirstWednesday;
            }

            return Wednesdays;

        }
    }
}
