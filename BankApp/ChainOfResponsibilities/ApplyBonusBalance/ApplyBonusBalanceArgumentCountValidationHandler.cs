using BankApp.ChainOfResponsibilities.Contracts;
using BankApp.ChainOfResponsibilities.Contracts.ApplyBonusBalance;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.ApplyBonusBalance
{
    public class ApplyBonusBalanceArgumentCountValidationHandler : Handler, IApplyBonusBalanceArgumentCountValidationHandler
    {
        private readonly ILogProvider _logger;

        public ApplyBonusBalanceArgumentCountValidationHandler(ILogProvider logger)
        {
            _logger = logger;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            if (arguments.Count != 0)
            {
                _logger.Log("Invalid number of arguments for checking balance. Usage: /apply-bonus-balance");
                return false;
            }

            return Successor?.HandleRequest(arguments) ?? true;
        }

    }
}
