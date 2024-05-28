namespace BankApp.Commands.Contracts
{
    public interface ICommand
    {
        void Execute(ICollection<string> arguments);
    }
}
