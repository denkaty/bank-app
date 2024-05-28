using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transfer
{
    public class TransferRecipientIdValidationHandler : Handler, ITransferRecipientIdValidationHandler
    {
        private readonly ILogProvider _logger;

        public TransferRecipientIdValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            string recipientIdAsString = arguments.ElementAt(1);
            int recipientId = -1;
            try
            {
                recipientId = int.Parse(recipientIdAsString);
            }
            catch (Exception)
            {
                _logger.Log($"Provided recipientId '{recipientIdAsString}' is not valid.");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
