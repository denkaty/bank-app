using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transfer
{
    public class TransferArgumentCountValidationHandler : Handler, ITransferArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public TransferArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 3)
            {
                _logger.Log("Invalid number of arguments for transfer. Usage: /transfer <senderId> <recipientId> <amount>");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }

    }
}
