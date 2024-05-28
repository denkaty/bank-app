using BankApp.ChainOfResponsibilities.Contracts.CreateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.CreateClient
{
    public class CreateClientValidationHandler : Handler, ICreateClientValidationHandler
    {
        private readonly ICreateClientArgumentCountValidationHandler _firstHandler;

        public CreateClientValidationHandler(ICreateClientArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);
        }
    }
}
