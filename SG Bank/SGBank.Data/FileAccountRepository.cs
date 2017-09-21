using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;


namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private string _liveAccounts = @"C:\repos\Bitbucket\Data\SG-Bank\Accounts.txt";
        Account account = new Account();

        private List<Account> _getAllAccounts()
        {
            List<Account> accounts = new List<Account>();
            //try catch here? Could catch out of range exception
            using (StreamReader sr = new StreamReader(_liveAccounts))
            {
                sr.ReadLine();

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();
                    string[] columns = line.Split(',');

                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = decimal.Parse(columns[2]);
                    switch (columns[3])
                    {
                        case "F":
                            newAccount.Type = AccountType.Free;
                            break;
                        case "B":
                            newAccount.Type = AccountType.Basic;
                            break;
                        case "P":
                            newAccount.Type = AccountType.Premium;
                            break;
                    }
                    accounts.Add(newAccount);

                }

            }
            return accounts;

        }

        public Account LoadAccount(string AccountNumber)
        {

            var list = _getAllAccounts();


            var ParticularAccount = (from account in _getAllAccounts()
                                     where account.AccountNumber == AccountNumber
                                     select account).FirstOrDefault();
            var index = (from account in list
                        where account.AccountNumber == AccountNumber
                        select list.IndexOf(account)).FirstOrDefault();
            ParticularAccount.index = index;

            return ParticularAccount;
        }




        //AccountNumber,Name,Balance,Type
        private string _createCvsForAccountFile(Account account)
        {
            string accountTypeForFormat = "";

            switch (account.Type)
            {
                case AccountType.Free:
                    accountTypeForFormat = "F";
                    break;
                case AccountType.Basic:
                    accountTypeForFormat = "B";
                    break;
                case AccountType.Premium:
                    accountTypeForFormat = "P";
                    break;
            }

            return string.Format($"{account.AccountNumber},{account.Name},{account.Balance},{accountTypeForFormat}");
        }


        private void _createAccountFile(List<Account> accounts)
        {
            if (File.Exists(_liveAccounts))
            {
                File.Delete(_liveAccounts);
            }

            using (StreamWriter sr = new StreamWriter(_liveAccounts))
            {
                sr.WriteLine("AccountNumber,Name,Balance,Type");
                foreach (var account in accounts)
                {
                    sr.WriteLine(_createCvsForAccountFile(account));
                }
            }
        }

        public void SaveAccount(Account account1)
        {
            account = account1;
            List<Account> accounts = _getAllAccounts();
            //when it goes to save, could catch an exception here.
            accounts[account.index] = account;
            _createAccountFile(accounts);

        }
    }
}
