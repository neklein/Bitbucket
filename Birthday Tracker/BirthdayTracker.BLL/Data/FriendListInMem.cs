using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.BLL.Data
{
    public class FriendListInMemStub : IFriendList
    {
        private List<Friend> _inMemoryList;

        public FriendListInMemStub()
        {
            _inMemoryList = new List<Friend>();
            Friend first = new Friend()
            {
                Name = "Jonathan",
                Birthday = DateTime.Parse("11/30/1975")
            };
            _inMemoryList.Add(first);
        }
        public void AddFriendToList(Friend friend)
        {
        }

        public List<Friend> GetFriendByBirthday(DateTime birthday)
        {
            return _inMemoryList;
        }
    }
}
