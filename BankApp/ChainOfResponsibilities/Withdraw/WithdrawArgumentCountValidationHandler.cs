using BankApp.ChainOfResponsibilities.Contracts.Withdraw;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Withdraw
{
    public class WithdrawArgumentCountValidationHandler : Handler, IWithdrawArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public WithdrawArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 2)
            {
                _logger.Log("Invalid number of arguments for depositing. Usage: /withdraw <clientId> <amount>");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
