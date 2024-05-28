using BankApp.ChainOfResponsibilities.Contracts.Transactions;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transactions
{
    public class TransactionsArgumentCountValidationHandler : Handler, ITransactionsArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public TransactionsArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 0)
            {
                _logger.Log("Invalid number of arguments for listing transactions. Usage: /transactions");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
