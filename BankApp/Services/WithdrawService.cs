using BankApp.Entities;
using BankApp.Factories.TaxCalculationStrategyFactory.Contracts;
using BankApp.Services.Contracts;
using BankApp.Strategies.TaxCalculationStrategies.Contracts;

namespace BankApp.Services;

public class WithdrawService : IWithdrawService
{
    private readonly IClientService _clientService;
    private readonly ITaxCalculationStrategyFactory _taxCalculationStrategyFactory;

    public WithdrawService(IClientService clientService, ITaxCalculationStrategyFactory taxCalculationStrategyFactory)
    {
        _clientService = clientService;
        _taxCalculationStrategyFactory = taxCalculationStrategyFactory;
    }
    public decimal Withdraw(int clientId, decimal amount)
    {
        Client? client = _clientService.GetById(clientId);
        if (client == null) { throw new InvalidOperationException($"Client with ID '{clientId}' not found."); }

        ITaxCalculationStrategy taxCalculationStrategy = _taxCalculationStrategyFactory.GetTaxCalculationStrategy(client.Type);
        decimal tax = taxCalculationStrategy.CalculateTax(amount);
        decimal totalWithdrawalAmount = amount + tax;

        client.Account.Withdraw(totalWithdrawalAmount);
        return totalWithdrawalAmount;
    }
}