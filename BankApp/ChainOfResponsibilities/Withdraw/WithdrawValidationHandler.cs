using BankApp.ChainOfResponsibilities.Contracts.Withdraw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Withdraw
{
    public class WithdrawValidationHandler : Handler, IWithdrawValidationHandler
    {
        private readonly IWithdrawArgumentCountValidationHandler _firstHandler;

        public WithdrawValidationHandler(IWithdrawArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }
    }
}
