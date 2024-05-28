using BankApp.ChainOfResponsibilities.Contracts.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Balance
{
    public class BalanceClientIdValidationHandler : Handler, IBalanceClientIdValidationHandler
    {
        public override bool HandleRequest(ICollection<string> arguments)
        {
            string clientIdAsString = arguments.ElementAt(0);
            int clientId = -1;
            if (!int.TryParse(clientIdAsString, out clientId))
            {
                Console.WriteLine($"Provided clientId '{clientIdAsString}' is not valid.");
                return false;
            }

            return true;
        }
    }
}
