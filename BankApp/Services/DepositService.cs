using BankApp.Entities;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;

namespace BankApp.Services
{
    public class DepositService : IDepositService
    {
        private readonly IClientRepository _clientRepository;

        public DepositService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public void Deposit(int clientId, decimal amount)
        {
            Client? client = _clientRepository.GetById(clientId);
            if (client == null) { throw new InvalidOperationException($"Client with ID '{clientId}' not found."); }

            client.Account.Deposit(amount);
        }

    }
}
