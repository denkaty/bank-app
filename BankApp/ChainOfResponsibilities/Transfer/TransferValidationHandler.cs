using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transfer
{
    public class TransferValidationHandler : Handler, ITransferValidationHandler
    {
        private readonly ITransferArgumentCountValidationHandler _firstHandler;

        public TransferValidationHandler(ITransferArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }

    }
}
