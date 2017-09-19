using NUnit.Framework;
using SGBank.Data;
using SGBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Test
{
    [TestFixture]
    public class StudentAccountAccessTests
    {
        [Test]
        public void CanReadDataFromFile()
        {
            //FileAccountRepository repo = new FileAccountRepository(@"C:\repos\Bitbucket\Data\SG-Bank\AccountsTest.txt");

            //List<Account> accounts = repo.AccountList();
       
            //Assert.AreEqual(3, accounts.Count());

            ////33333,Premium Customer,1000,P
            //Account check = accounts[2];
            //Assert.AreEqual("33333", check.AccountNumber);
            //Assert.AreEqual("Premium Customer", check.Name);
            //Assert.AreEqual(1000M, check.Balance);
            //Assert.AreEqual(AccountType.Premium, check.Type);

        }
    }
}
