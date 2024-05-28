using BankApp.ChainOfResponsibilities.Contracts.CreateClient;
using BankApp.LogProviders.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.CreateClient
{
    public class CreateClientArgumentCountValidationHandler : Handler, ICreateClientArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public CreateClientArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 1)
            {
                _logger.Log("Invalid number of arguments for creating a client. Usage: /create <name>");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
