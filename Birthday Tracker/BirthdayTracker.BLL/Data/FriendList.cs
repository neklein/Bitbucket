using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.BLL.Data
{
    public class FriendList
    {
        private Dictionary<DateTime, List<Friend>> MyFriendList { get; set; }

        public FriendList()
        {
            MyFriendList = new Dictionary<DateTime, List<Friend>>();
        }

        public void AddFriendToList(Friend friend)
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
    }
}
