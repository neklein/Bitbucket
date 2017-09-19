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
    public class PremiumAccountWithdrawalRules : IWithdrawal
    {
        public AccountWithdrawalResponse Withdrawal(Account account, decimal amount)
        {
            AccountWithdrawalResponse response = new AccountWithdrawalResponse();

            if (account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "Error: a non-premium account hit the Premium Withdraw Rule. Contact IT";
                return response;
            }
            if (amount >= 0)
            {
                response.Success = false;
                response.Message = "Withdrawal amounts must be negative!";
                return response;
            }
            if (amount < -5000)
            {
                response.Success = false;
                response.Message = "Premium accounts cannot withdraw more than $5000!";
                return response;
            }
            if ((account.Balance + amount) < -1000)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $1000 limit!";
                return response;
            }
            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;
            if (account.Balance < 0)
            {
                account.Balance -= 50;
            }

            return response;
        }
    }
}
