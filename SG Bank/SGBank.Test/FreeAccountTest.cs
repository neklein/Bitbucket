﻿using NUnit.Framework;
using SGBank.BLL;
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
    public class FreeAccountTests
    { 
        [Test]
        public void CanLoadFreeAccountTestData()
        {
            AccountManager manager = AccountManagerFactory.Create();

            AccountLookupResponse response = manager.LookupAccount("12345");

            Assert.IsNotNull(response.Account);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("12345", response.Account.AccountNumber);
        }

        [TestCase ("12345", "Free Account", 100, AccountType.Free, 250, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -100, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, 50, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, 50, true)]
        public void FreeAccountDepositRuleTest(string accountNumber, string name, 
            decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {

            IDeposit deposit = new FreeAccountDepositRule();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositReponse depositReponse = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, depositReponse.Success);
            
        }

        [TestCase("12345", "Free Account", 100, AccountType.Free, 20, false)]
        [TestCase("12345", "Free Account", 200, AccountType.Free, -101, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Basic, -50, false)]
        [TestCase("12345", "Free Account", 50, AccountType.Free, -60, false)]
        [TestCase("12345", "Free Account", 100, AccountType.Free, -25, true)]
        public void FreeAccountWithdrawalRuleTest(string accountNumber, string name,
            decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {

            IWithdrawal withdraw = new FreeAccountWithdrawalRules();

            Account account = new Account();
            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawalResponse withdrawResponse = withdraw.Withdrawal(account, amount);

            Assert.AreEqual(expectedResult, withdrawResponse.Success);

        }


    }
}