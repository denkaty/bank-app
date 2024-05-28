using BankApp.Commands.Contracts;
using BankApp.Factories.CommandFactory;
using BankApp.Helpers.Contracts;
using BankApp.LogProviders.Contracts;

namespace BankApp.Helpers
{
    public class CommandExecutor : ICommandExecutor
    {
        private readonly ILogProvider _logger;
        private readonly ICommandFactory _commandFactory;

        public CommandExecutor(ILogProvider logger, ICommandFactory commandFactory)
        {
            _logger = logger;
            _commandFactory = commandFactory;
        }

        public void ExecuteCommand(string commandName, string[] commandArguments)
        {
            ICommand? command = _commandFactory.Create(commandName);
            if (command == null)
            {
                _logger.Log("Invalid command.");
                return;
            }

            try
            {
                command.Execute(commandArguments);
            }
            catch (Exception ex)
            {
                _logger.Log($"An error occurred while executing the command: {ex.Message}");
            }
        }
    }
}
