using BankApp.ChainOfResponsibilities.Contracts.CheckWithdrawals;
using BankApp.Commands.Contracts;
using BankApp.Entities;
using BankApp.Jobs.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands
{
    public class CheckWithdrawalsCommand : ICheckWithdrawalsCommand
    {
        private readonly ICheckWithdrawalsValidationHandler _validationHandler;
        private readonly ICheckWithdrawalsCountJob _checkWithdrawalsCountJob;
        private readonly ILogProvider _logger;

        public CheckWithdrawalsCommand(ICheckWithdrawalsValidationHandler validationHandler, ICheckWithdrawalsCountJob checkWithdrawalsCountJob, ILogProvider logger)
        {
            _validationHandler = validationHandler;
            _checkWithdrawalsCountJob = checkWithdrawalsCountJob;
            _logger = logger;
        }

        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            try
            {
                _checkWithdrawalsCountJob.Execute();
                _logger.Log($"Withdrawal count check completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.Log($"Error during withdrawal count check: {ex.Message}");
            }
        }
    }
}
