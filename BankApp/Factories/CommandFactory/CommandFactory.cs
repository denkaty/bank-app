using BankApp.Commands.Contracts;

namespace BankApp.Factories.CommandFactory
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDictionary<string, Type> _commandTypes;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _commandTypes = new Dictionary<string, Type>
            {
                { "/create", typeof(ICreateClientCommand) },
                { "/deposit", typeof(IDepositCommand) },
                { "/withdraw", typeof(IWithdrawCommand) },
                { "/balance", typeof(IBalanceCommand) },
                { "/transfer", typeof(ITransferCommand) },
                { "/clients", typeof(IClientsCommand) },
                { "/transactions", typeof(ITransactionsCommand)},
                { "/check-withdrawals", typeof(ICheckWithdrawalsCommand)},
                { "/apply-bonus-balance", typeof(IApplyBonusBalanceCommand)}
            };
        }

        public ICommand? Create(string commandName)
        {
            if (!_commandTypes.ContainsKey(commandName.ToLower()))
            {
                return null;
            }

            Type commandType = _commandTypes[commandName.ToLower()];
            var service = _serviceProvider.GetService(commandType);
            return service as ICommand;
        }
    }
}
