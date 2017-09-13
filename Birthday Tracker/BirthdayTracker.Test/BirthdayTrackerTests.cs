using BirthdayTracker.BLL.Data;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.Test
{
    public class IFriendListTest
    {
        [Test]
        public void TestGetFriend()
        {

            IFriendList test = FriendListFactory.Create();
            List<Friend> result = test.GetFriendByBirthday(new DateTime());

            Assert.AreEqual(result.Count, 1);

        }
    }
}
