using BankApp.ChainOfResponsibilities.Contracts.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Transactions
{
    public class TransactionsValidationHandler : Handler, ITransactionsValidationHandler
    {
        private readonly ITransactionsArgumentCountValidationHandler _firstHandler;

        public TransactionsValidationHandler(ITransactionsArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }
    }
}
