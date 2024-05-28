using BankApp.Entities;
using BankApp.Factories.TaxCalculationStrategyFactory.Contracts;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;
using BankApp.Strategies.TaxCalculationStrategies.Contracts;

namespace BankApp.Services
{
    public class TransferService : ITransferService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ITaxCalculationStrategyFactory _taxCalculationStrategyFactory;

        public TransferService(IClientRepository clientRepository, ITaxCalculationStrategyFactory taxCalculationStrategyFactory)
        {
            _clientRepository = clientRepository;
            _taxCalculationStrategyFactory = taxCalculationStrategyFactory;
        }

        public void Transfer(int senderId, int recipientId, decimal amount)
        {
            Client? sender = _clientRepository.GetById(senderId);
            if (sender == null) { throw new InvalidOperationException($"Sender with ID '{senderId}' not found."); }

            Client? recipient = _clientRepository.GetById(recipientId);
            if (recipient == null) { throw new InvalidOperationException($"Recipient with ID '{recipientId}' not found."); }

            ITaxCalculationStrategy taxCalculationStrategy = _taxCalculationStrategyFactory.GetTaxCalculationStrategy(sender.Type);
            decimal tax = taxCalculationStrategy.CalculateTax(amount);
            decimal totalWithdrawalAmount = amount + tax;

            sender.Account.Withdraw(totalWithdrawalAmount);
            recipient.Account.Deposit(amount);

        }
    }
}
