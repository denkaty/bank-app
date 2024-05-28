using BankApp.ChainOfResponsibilities.Contracts.CheckWithdrawals;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.CheckWithdrawals
{
    public class CheckWithdrawalsArgumentCountValidationHandler : Handler, ICheckWithdrawalsArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public CheckWithdrawalsArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 0)
            {
                _logger.Log("Invalid number of arguments for checking balance. Usage: /check-withdrawals");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }
    }
}
