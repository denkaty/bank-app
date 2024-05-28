using BankApp.Entities;

namespace BankApp.Proxies.Contracts;

public interface IBankFacade
{
    decimal GetBalance(int clientId);

    void CreateClient(string name);

    ICollection<Client> GetAllClients();

    void Deposit(int clientId, decimal amount);

    void Transfer(int senderId, int recipientId, decimal amount);

    decimal Withdraw(int clientId, decimal amount);
    ICollection<Transaction> GetAllTransactions();
}