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
            throw new NotImplementedException();
        }
    }
}
