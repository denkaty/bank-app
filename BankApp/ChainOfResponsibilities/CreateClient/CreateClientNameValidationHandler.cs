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
    public class CreateClientNameValidationHandler : Handler, ICreateClientNameValidationHandler
    {
        private readonly ILogProvider _logger;

        public CreateClientNameValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            string name = arguments.ElementAt(0);
            if (string.IsNullOrEmpty(name))
            {
                _logger.Log("Name cannot be empty.");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
