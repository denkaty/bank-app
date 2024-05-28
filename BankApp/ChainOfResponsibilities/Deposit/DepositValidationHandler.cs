using BankApp.ChainOfResponsibilities.Contracts.Deposit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Deposit
{
    public class DepositValidationHandler : Handler, IDepositValidationHandler
    {
        private readonly IDepositArgumentCountValidationHandler _firstHandler;

        public DepositValidationHandler(IDepositArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }
    }
}
