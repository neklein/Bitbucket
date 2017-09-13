using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class FreeAccountDepositRule : IDeposit
    {
        //there will be different deposit rules depending on type
        public AccountDepositReponse Deposit(Account account, decimal amount)
        {
            AccountDepositReponse response = new AccountDepositReponse();
            if(account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = "Error: a non free account hit the Free Deposit Rule. Contact IT";
                return response;
            }

            if(amount > 100)
            {
                response.Success = false;
                response.Message = "Free accounts cannot deposit more than $100 at a time.";
                return response;
            }

            if(amount <= 0)
            {
                response.Success = false;
                response.Message = "You must deposit an amount greater than zero.";
                return response;
            }

            response.OldBalance = account.Balance;
            account.Balance += amount;
            response.Account = account;
            response.Amount = amount;
            response.Success = true;
            return response;
        }
    }
}
