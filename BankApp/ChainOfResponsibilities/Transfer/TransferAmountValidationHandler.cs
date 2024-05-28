using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transfer
{
    public class TransferAmountValidationHandler : Handler, ITransferAmountValidationHandler
    {
        private readonly ILogProvider _logger;

        public TransferAmountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            string amountAsString = arguments.ElementAt(2);
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
