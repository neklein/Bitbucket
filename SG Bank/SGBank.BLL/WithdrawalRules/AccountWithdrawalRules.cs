using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawalRules
{
    public class AccountWithdrawalRules : IWithdrawal
    {
        public AccountWithdrawalResponse Withdrawal(Account account, decimal amount)
        {
            AccountWithdrawalResponse response = new AccountWithdrawalResponse();
            if (amount <= 0)
            {
                response.Success = false;
                response.Message = "You must withdraw an amount greater than zero.";
                return response;
            }
            if(amount > account.Balance)
            {
                response.Success = false;
                response.Message = "You cannot withdraw more money than is available in your account.";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance -= amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;
            return response;
        }

    }
}

