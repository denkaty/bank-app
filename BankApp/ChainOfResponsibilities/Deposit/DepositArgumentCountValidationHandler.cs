using BankApp.ChainOfResponsibilities.Contracts.Deposit;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Deposit
{
    public class DepositArgumentCountValidationHandler : Handler, IDepositArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public DepositArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 2)
            {
                _logger.Log("Invalid number of arguments for depositing. Usage: /deposit <clientId> <amount>");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
