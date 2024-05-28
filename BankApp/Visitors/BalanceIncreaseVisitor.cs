using BankApp.Entities;
using BankApp.Visitors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Visitors
{
    public class BalanceIncreaseVisitor : IBalanceIncreaseVisitor
    {
        public void Visit(Client client)
        {
            decimal increaseAmount = client.Account.Balance * 0.1m;
            client.Account.Deposit(increaseAmount);
        }
    }
}
