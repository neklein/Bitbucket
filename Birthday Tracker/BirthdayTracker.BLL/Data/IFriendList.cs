using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayTracker.BLL.Data
{
    public interface IFriendList
    {
        void AddFriendToList(Friend friend);

        List<Friend> GetFriendByBirthday(DateTime birthday);


    }
}
