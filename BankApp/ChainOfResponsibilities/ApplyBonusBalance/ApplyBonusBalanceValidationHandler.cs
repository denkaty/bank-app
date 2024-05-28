using BankApp.ChainOfResponsibilities.Contracts;
using BankApp.ChainOfResponsibilities.Contracts.ApplyBonusBalance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.ApplyBonusBalance
{
    public class ApplyBonusBalanceValidationHandler : Handler, IApplyBonusBalanceValidationHandler
    {
        private readonly IApplyBonusBalanceArgumentCountValidationHandler _firstHandler;

        public ApplyBonusBalanceValidationHandler(IApplyBonusBalanceArgumentCountValidationHandler firstHandler)
        {
            _firstHandler = firstHandler;
        }

        public override bool HandleRequest(ICollection<string> arguments)
        {
            return _firstHandler.HandleRequest(arguments);

        }

    }
}
