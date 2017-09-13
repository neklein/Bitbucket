﻿using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Interfaces
{
    public interface IWithdrawal
    {
        AccountWithdrawalResponse Withdrawal(Account account, decimal amount);
    }
}
