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
    public class FreeAccountWithdrawalRules : IWithdrawal
    {
        public AccountWithdrawalResponse Withdrawal(Account account, decimal amount)
        {
            AccountWithdrawalResponse response = new AccountWithdrawalResponse();
            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free account hit the Free Deposit Rule. Contact IT";
                return response;
            }

            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "You must use a negative number to withdraw money from your account.";
                return response;
            }
            if(Math.Abs(amount) > 100)
            {
                response.Success = false;
                response.Message = "Free accounts cannot withdraw more than $100";
                return response;
            }
            if(Math.Abs(amount) > account.Balance)
            {
                response.Success = false;
                response.Message = "Free accounts cannot overdraft.";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance -= Math.Abs(amount);
            response.Account = account;
            response.Amount = amount;
            response.Success = true;
            return response;
        }

    }
}

