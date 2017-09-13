using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BirthdayTracker.BLL.Data;

namespace BirthdayTracker.UI
{
    public class ProgramFlow
    {
        private IFriendList ListOFriends { get; set; }
        public ProgramFlow(IFriendList list)
        {
            ListOFriends = list;
        }

        public void Start()
        {
            ConsoleOutput.DisplayMessage();

            do
            {
                //Friend first = new Friend()
                //{
                //    Name = "Jonathan",
                //    Birthday = DateTime.Parse("11/30/1975")
                //};
                //Friend second = new Friend()
                //{
                //    Name = "Kory",
                //    Birthday = DateTime.Parse("12/18/1975")
                //};
                //Friend third = new Friend()
                //{
                //    Name = "Kirk",
                //    Birthday = DateTime.Parse("12/18/1975")
                //};
                //////Friend fifth = new Friend()
                //////{
                //////    Name = "Michael",
                //////    Birthday = DateTime.Parse("9/17/1980")
                //////};

                //ListOfFriends.AddFriendToList(first);
                //ListOfFriends.AddFriendToList(second);
                //ListOfFriends.AddFriendToList(third);
                //ListOfFriends.AddFriendToList(fifth);

                DateTime date = ConsoleInput.AskForBirthday();
                ConsoleOutput.DisplayFriendHeader();

                foreach (Friend friend in ListOFriends.GetFriendByBirthday(date))
                {
                    ConsoleOutput.DisplayFriend(friend);
                }

                ConsoleInput.KeyToContinue("Press any key to continue");
                Console.Clear();
            } while (ConsoleInput.KeyToContinue("Press Y if you want to run again.").ToUpper().Equals("Y"));
        }
    }
}
