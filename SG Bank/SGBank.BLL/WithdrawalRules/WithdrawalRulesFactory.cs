using SGBank.Models;
using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.BLL.WithdrawalRules
{
    public class WithdrawalRulesFactory
    {
        public static IWithdrawal Create(AccountType type)
        {
            switch (type)
            {
                case AccountType.Free:
                    return new FreeAccountWithdrawalRules();
                case AccountType.Basic:
                    return new BasicAccountWithdrawalRules();
                case AccountType.Premium:
                    return new PremiumAccountWithdrawalRules();

            }
            throw new Exception("Account type is not supported!");
        }

    }
}
