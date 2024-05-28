namespace BankApp.Helpers.Contracts
{
    public interface ICommandExecutor
    {
        void ExecuteCommand(string commandName, string[] commandArguments);
    }
}
