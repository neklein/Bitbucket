using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.BLL.Data
{
    public class FriendListFileImpl : IFriendList
    {
        private Dictionary<DateTime, List<Friend>> MyFriendList { get; set; }
        private string fileName = @".\Friends.txt";

        public FriendListFileImpl()
        {
            MyFriendList = new Dictionary<DateTime, List<Friend>>();
            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }
            ReadFriendsFromFile();
        }

        public void AddFriendToList(Friend friend)
        {
            PrivateAddFriend(friend);
            WriteFriendsToFile();
        }

        public List<Friend> GetFriendByBirthday(DateTime birthday)
        {
            if (MyFriendList.ContainsKey(birthday))
            {
                return MyFriendList[birthday];

            }
            else
            {
                return new List<Friend>();
            }
        }

        private void ReadFriendsFromFile()
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] values = line.Split('~');
                    Friend friendToAdd = new Friend();
                    friendToAdd.Name = values[0];
                    friendToAdd.Birthday = DateTime.Parse(values[1]);
                    PrivateAddFriend(friendToAdd);
                }
            }
        }

        private void WriteFriendsToFile()
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach(List<Friend> list in MyFriendList.Values)
                {
                    foreach(Friend friend in list)
                    {
                        writer.WriteLine($"{friend.Name}~{friend.Birthday.ToString("M-d-yyyy")}");
                    }
                }
            }
        }

        private void PrivateAddFriend(Friend friend)
        {
            if (MyFriendList.Keys.Contains(friend.Birthday))
            {
                MyFriendList[friend.Birthday].Add(friend);

            }
            else
            {
                List<Friend> listToAdd = new List<Friend>();
                listToAdd.Add(friend);
                MyFriendList.Add(friend.Birthday, listToAdd);
            }

        }
    }
}
