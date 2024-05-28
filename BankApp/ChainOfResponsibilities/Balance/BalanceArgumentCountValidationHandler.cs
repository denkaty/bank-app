using BankApp.ChainOfResponsibilities.Contracts.Balance;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Balance
{
    public class BalanceArgumentCountValidationHandler : Handler, IBalanceArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public BalanceArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 1)
            {
                _logger.Log("Invalid number of arguments for checking balance. Usage: /balance <clientId>");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;

        }
    }
}
