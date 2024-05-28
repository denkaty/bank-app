using BankApp.ChainOfResponsibilities.Contracts.CreateClient;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;

namespace BankApp.Commands
{
    public class CreateClientCommand : BaseCommand, ICreateClientCommand
    {
        private readonly ICreateClientValidationHandler _validationHandler;

        public CreateClientCommand(ILogProvider logger, IBankFacade bankFacade, ICreateClientValidationHandler validationHandler)
            : base(logger, bankFacade) 
        {
            _validationHandler = validationHandler;
        }

        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            var name = arguments.ElementAt(0);

            try
            {
                BankFacade.CreateClient(name);
                Logger.Log($"Client '{name}' has been created successfully.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to create client: {ex.Message}");
            }

        }
    }
}
