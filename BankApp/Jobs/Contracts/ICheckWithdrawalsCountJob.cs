﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Jobs.Contracts
{
    public interface ICheckWithdrawalsCountJob
    {
        void Execute();
    }
}
