using BankApp.ChainOfResponsibilities.Contracts.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Balance
{
    public class BalanceValidationHandler : Handler, IBalanceValidationHandler
    {
        private readonly IBalanceArgumentCountValidationHandler _firstHandler;

        public BalanceValidationHandler(IBalanceArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }

    }
}
