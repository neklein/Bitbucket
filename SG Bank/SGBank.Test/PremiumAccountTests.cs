using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawalRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Test
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("55555", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 250, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositReponse response = new AccountDepositReponse();
            response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("55555", "Premium Account", 6000, AccountType.Premium, -5001, 6000, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Free, -90, 100, false)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, 100, 100, false)]
        [TestCase("55555", "Premium Account", 150, AccountType.Premium, -50, 100, true)]
        [TestCase("55555", "Premium Account", 100, AccountType.Premium, -150, -100, true)]
        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdrawal withdrawal = new PremiumAccountWithdrawalRules();
            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawalResponse response = new AccountWithdrawalResponse();
            response = withdrawal.Withdrawal(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
            if (response.Success == true)
            {
                Assert.AreEqual(newBalance, account.Balance);
            }
        }


    }
}
