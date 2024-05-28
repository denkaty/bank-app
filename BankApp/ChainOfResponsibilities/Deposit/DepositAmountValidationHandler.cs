using BankApp.ChainOfResponsibilities.Contracts.Deposit;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Deposit
{
    public class DepositAmountValidationHandler : Handler, IDepositAmountValidationHandler
    {
        private readonly ILogProvider _logger;

        public DepositAmountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            string amountAsString = arguments.ElementAt(1);
            decimal amount = 0;
            try
            {
                amount = decimal.Parse(amountAsString);

                if (amount <= 0) { throw new ArgumentException($"The provided amount '{amountAsString}' is not valid. Amount must be a positive number."); }
            }
            catch (Exception)
            {
                _logger.Log($"Provided amount '{amountAsString}' is not valid.");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
