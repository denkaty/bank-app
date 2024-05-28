using BankApp.ChainOfResponsibilities.Contracts.Deposit;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;

namespace BankApp.Commands
{
    public class DepositCommand : BaseCommand, IDepositCommand
    {
        private readonly IDepositValidationHandler _validationHandler;

        public DepositCommand(ILogProvider logger, IBankFacade bankFacade, IDepositValidationHandler validationHandler)
            : base(logger, bankFacade)
        {
            _validationHandler = validationHandler;
        }

        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            var clientId = int.Parse(arguments.ElementAt(0));
            var amount = decimal.Parse(arguments.ElementAt(1));

            try
            {
                BankFacade.Deposit(clientId, amount);
                Logger.Log($"Deposit of {amount} for client with ID '{clientId}' was successful.");

            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to deposit: {ex.Message}");
            }
        }

    }
}
