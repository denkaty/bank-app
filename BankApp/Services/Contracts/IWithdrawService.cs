namespace BankApp.Services.Contracts;

public interface IWithdrawService
{
    decimal Withdraw(int clientId, decimal amount);
}