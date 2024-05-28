using BankApp.ChainOfResponsibilities.Contracts.CheckWithdrawals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.CheckWithdrawals
{
    public class CheckWithdrawalsValidationHandler : Handler, ICheckWithdrawalsValidationHandler
    {
        private readonly ICheckWithdrawalsArgumentCountValidationHandler _firstHandler;

        public CheckWithdrawalsValidationHandler(ICheckWithdrawalsArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }

    }
}
