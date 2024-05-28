using BankApp.Engines.Contracts;
using BankApp.Helpers.Contracts;
using BankApp.LogProviders.Contracts;

namespace BankApp.Engines
{
    public class BankEngine : IBankEngine
    {
        private readonly ILogProvider _logger;
        private readonly ICommandExecutor _commandExecutor;

        public BankEngine(ILogProvider logger, ICommandExecutor commandExecutor)
        {
            _logger = logger;
            _commandExecutor = commandExecutor;
        }

        public void Run()
        {
            _logger.Log("Welcome to the Bank Application!");

            while (true)
            {
                DisplayMenu();

                string input = _logger.ReadLine().Trim().ToLower();

                if (input == "exit") { break; }

                _logger.Clear();

                if (string.IsNullOrEmpty(input))
                {
                    _logger.Log("Please enter a valid command.");
                    continue;
                }

                string[] commandArgs = input.Split(' ');

                string commandName = commandArgs[0];
                string[] commandArguments = commandArgs.Length > 1
                                            ? commandArgs[1..]
                                            : Array.Empty<string>();

                _commandExecutor.ExecuteCommand(commandName, commandArguments);
            }
        }

        private void DisplayMenu()
        {
            _logger.Log();
            _logger.Log("Available commands:");
            _logger.Log("/create <name>: Create a new client");
            _logger.Log("/deposit <clientId> <amount>: Perform a deposit");
            _logger.Log("/withdraw <clientId> <amount>: Perform a withdrawal");
            _logger.Log("/balance <clientId>: Retrieve balance");
            _logger.Log("/transfer <senderId> <recipientId> <amount>: Transfer money between clients");
            _logger.Log("/clients: List all clients");
            _logger.Log("/transactions: List all transactions");
            _logger.Log("/check-withdrawals: Executes scheduled job");
            _logger.Log("/apply-bonus-balance: Executes scheduled job");
            _logger.Log();
            _logger.Log("Enter a command (or 'exit' to quit):");
        }

        
    }
}
