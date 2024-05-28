using BankApp.ChainOfResponsibilities.Contracts;
using BankApp.ChainOfResponsibilities.Contracts.Balance;
using BankApp.ChainOfResponsibilities.Contracts.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Clients
{
    public class ClientsValidationHandler : Handler, IClientsValidationHandler
    {
        private readonly IClientsArgumentCountValidationHandler _firstHandler;

        public ClientsValidationHandler(IClientsArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }

    }
}
