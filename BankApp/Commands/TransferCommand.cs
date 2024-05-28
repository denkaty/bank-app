using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;

namespace BankApp.Commands
{
    public class TransferCommand : BaseCommand, ITransferCommand
    {
        private readonly ITransferValidationHandler _validationHandler;

        public TransferCommand(ILogProvider logger, IBankFacade bankFacade, ITransferValidationHandler validationHandler)
            : base(logger, bankFacade)
        {
            _validationHandler = validationHandler;
        }

        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            int senderId = int.Parse(arguments.ElementAt(0));
            int recipientId = int.Parse(arguments.ElementAt(1));
            decimal amount = int.Parse(arguments.ElementAt(2));

            try
            {
                BankFacade.Transfer(senderId, recipientId, amount);
                Logger.Log($"Transfer of '{amount}' from client with ID '{senderId}' to client with ID '{recipientId}' was successful.");
            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to transfer: {ex.Message}");
            }
        }

    }
}
