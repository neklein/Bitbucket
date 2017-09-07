using BirthdayTracker.BLL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.UI
{
    public class ConsoleOutput
    {
        public static void DisplayMessage()
        {
            Console.WriteLine("Welcome to the birthday tracker!");
        }

        public static void DisplayFriendHeader()
        {
            Console.WriteLine($"Name{"",16}| Birthday{"",12}|");
        }

        public static void DisplayFriend(Friend friend)
        {
            Console.WriteLine($"{friend.Name,-20}| {friend.Birthday.ToString("MMM d"),-20}|");
        }
    }
}
