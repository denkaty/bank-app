using BankApp.ChainOfResponsibilities.Contracts.ApplyBonusBalance;
using BankApp.ChainOfResponsibilities.Contracts.CheckWithdrawals;
using BankApp.Commands.Contracts;
using BankApp.Jobs;
using BankApp.Jobs.Contracts;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands
{
    public class ApplyBonusBalanceCommand : IApplyBonusBalanceCommand
    {
        private readonly IApplyBonusBalanceValidationHandler _validationHandler;
        private readonly IApplyBonusBalanceJob _applyBonusBalanceJob;
        private readonly ILogProvider _logger;

        public ApplyBonusBalanceCommand(IApplyBonusBalanceValidationHandler validationHandler, IApplyBonusBalanceJob applyBonusBalanceJob, ILogProvider logger)
        {
            _validationHandler = validationHandler;
            _applyBonusBalanceJob = applyBonusBalanceJob;
            _logger = logger;
        }
        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            try
            {
                _applyBonusBalanceJob.Execute();
                _logger.Log($"Bonus balance applying completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.Log($"Error during bonus balance applying: {ex.Message}");
            }
        }
    }
}
