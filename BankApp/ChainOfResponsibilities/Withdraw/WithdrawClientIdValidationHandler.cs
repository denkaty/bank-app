using BankApp.ChainOfResponsibilities.Contracts.Withdraw;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Withdraw
{
    public class WithdrawClientIdValidationHandler : Handler, IWithdrawClientIdValidationHandler
    {
        private readonly ILogProvider _logger;

        public WithdrawClientIdValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            string clientIdAsString = arguments.ElementAt(0);
            int clientId = -1;
            try
            {
                clientId = int.Parse(clientIdAsString);
            }
            catch (Exception)
            {
                _logger.Log($"Provided clientId '{clientIdAsString}' is not valid.");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
