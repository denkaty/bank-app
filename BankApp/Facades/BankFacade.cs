using BankApp.Entities;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Proxies.Contracts;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;
using System.Reflection;

namespace BankApp.Proxies;

public class BankFacade : IBankFacade
{
    private readonly IBalanceProxy _balanceProxy;
    private readonly IClientProxy _clientProxy;
    private readonly IDepositProxy _depositProxy;
    private readonly ITransferProxy _transferProxy;
    private readonly IWithdrawProxy _withdrawProxy;
    private readonly ITransactionProxy _transactionProxy;

    public BankFacade(IBalanceProxy balanceProxy, IClientProxy clientProxy, IDepositProxy depositProxy, ITransferProxy transferProxy, IWithdrawProxy withdrawProxy, ITransactionProxy transactionProxy)
    {
        _balanceProxy = balanceProxy;
        _clientProxy = clientProxy;
        _depositProxy = depositProxy;
        _transferProxy = transferProxy;
        _withdrawProxy = withdrawProxy;
        _transactionProxy = transactionProxy;
    }

    public decimal GetBalance(int clientId)
    {
        return _balanceProxy.GetBalance(clientId);
    }

    public void CreateClient(string name)
    {
        _clientProxy.Create(name);
    }

    public ICollection<Client> GetAllClients()
    {
        return _clientProxy.GetAll();
    }

    public void Deposit(int clientId, decimal amount)
    {
        _depositProxy.Deposit(clientId, amount);
    }

    public void Transfer(int senderId, int recipientId, decimal amount)
    {
        _transferProxy.Transfer(senderId, recipientId, amount);
    }

    public decimal Withdraw(int clientId, decimal amount)
    {
        return _withdrawProxy.Withdraw(clientId, amount);
    }

    public ICollection<Transaction> GetAllTransactions()
    {
        return _transactionProxy.GetAll();
    }

}