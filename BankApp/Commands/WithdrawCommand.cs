using BankApp.ChainOfResponsibilities.Contracts.Withdraw;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;

namespace BankApp.Commands
{
    public class WithdrawCommand : BaseCommand, IWithdrawCommand
    {
        private readonly IWithdrawValidationHandler _validationHandler;

        public WithdrawCommand(ILogProvider logger, IBankFacade bankFacade, IWithdrawValidationHandler validationHandler)
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
                decimal totalWithdrawalAmount = BankFacade.Withdraw(clientId, amount);
                Console.WriteLine($"Withdrawal of '{amount}lv.' for client with ID '{clientId}' was successful. Amount withdrawn including taxes: '{totalWithdrawalAmount}lv.'");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to withdraw: {ex.Message}");
            }
        }
    }
}
