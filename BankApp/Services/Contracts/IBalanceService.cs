namespace BankApp.Services.Contracts
{
    public interface IBalanceService
    {
        decimal GetBalance(int clientId);
    }
}
