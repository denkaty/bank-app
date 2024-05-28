using BankApp.Entities;
using BankApp.Services.Contracts;

namespace BankApp.Services
{
    public class BalanceService : IBalanceService
    {
        private readonly IClientService _clientService;

        public BalanceService(IClientService clientService)
        {
            _clientService = clientService;
        }

        public decimal GetBalance(int clientId)
        {
            Client? client = _clientService.GetById(clientId);
            if (client == null) { throw new InvalidOperationException($"Client with ID '{clientId}' not found."); }

            decimal balance = client.Account.Balance;

            return balance;
        }
    }
}
