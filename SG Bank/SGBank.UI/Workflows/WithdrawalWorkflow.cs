﻿using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class WithdrawalWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountManager = AccountManagerFactory.Create();

            Console.WriteLine("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter a withdrawal amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawalResponse response = accountManager.Withdrawal(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdrawal Completed!");
                Console.WriteLine($"Account Number: {response.Account.AccountNumber}");
                Console.WriteLine($"Old Balance: {response.OldBalance:c}");
                Console.WriteLine($"Amount Withdrawn: {response.Amount:c}");
                Console.WriteLine($"New Balance: {response.Account.Balance:c}");
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
