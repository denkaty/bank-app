namespace BankApp.Services.Contracts
{
    public interface IDepositService
    {
        void Deposit(int clientId, decimal amount);
    }
}
