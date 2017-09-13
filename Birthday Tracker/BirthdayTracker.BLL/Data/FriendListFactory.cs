using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BirthdayTracker.BLL.Data
{
    public class FriendListFactory
    {
        public static IFriendList Create()
        {
            string listType = ConfigurationManager.AppSettings["Implementation"].ToString();

            if (listType == "File")
            {
                return new FriendListFileImpl();
            }
            else if (listType == "Stub")
            {
                return new FriendListInMemStub();
            }
            else
            {
                throw new Exception("App config has an invalid value for the implementation");
            }
        }
    }
}
