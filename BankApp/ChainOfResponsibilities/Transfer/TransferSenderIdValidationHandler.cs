using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transfer
{
    public class TransferSenderIdValidationHandler : Handler, ITransferSenderIdValidationHandler
    {
        private readonly ILogProvider _logger;

        public TransferSenderIdValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            string senderIdAsString = arguments.ElementAt(0);
            int senderId = -1;
            try
            {
                senderId = int.Parse(senderIdAsString);
            }
            catch (Exception)
            {
                _logger.Log($"Provided senderId '{senderIdAsString}' is not valid.");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
