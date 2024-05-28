using BankApp.ChainOfResponsibilities.Contracts.Balance;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;

namespace BankApp.Commands
{
    public class BalanceCommand : BaseCommand, IBalanceCommand
    {
        private readonly IBalanceValidationHandler _validationHandler;

        public BalanceCommand(ILogProvider logger, IBankFacade bankFacade, IBalanceValidationHandler validationHandler)
            : base(logger, bankFacade)
        {
            _validationHandler = validationHandler;
        }

        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            int clientId = int.Parse(arguments.ElementAt(0));
            try
            {
                decimal balance = BankFacade.GetBalance(clientId);
                Logger.Log($"Balance inquiry for client with ID '{clientId}' was successful. Current balance: {balance}");
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to retrieve balance for client with ID '{clientId}': {ex.Message}");
            }
        }

    }
}