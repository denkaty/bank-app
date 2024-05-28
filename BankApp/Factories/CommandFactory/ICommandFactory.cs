using BankApp.Commands.Contracts;

namespace BankApp.Factories.CommandFactory
{
    public interface ICommandFactory
    {
        ICommand? Create(string commandName);
    }
}
