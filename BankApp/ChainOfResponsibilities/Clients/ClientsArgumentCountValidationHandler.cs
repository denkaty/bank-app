using BankApp.ChainOfResponsibilities.Contracts;
using BankApp.ChainOfResponsibilities.Contracts.Clients;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Clients
{
    public class ClientsArgumentCountValidationHandler : Handler, IClientsArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public ClientsArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 0)
            {
                _logger.Log("Invalid number of arguments for listing clients. Usage: /clients");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
