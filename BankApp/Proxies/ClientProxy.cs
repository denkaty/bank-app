using BankApp.Entities;
using BankApp.Factories.TransactionFactory;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Proxies.Base;
using BankApp.Proxies.Contracts;
using BankApp.Repositories;
using BankApp.Repositories.Contracts;
using BankApp.Services;
using BankApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies
{
    public class ClientProxy : BaseProxy, IClientProxy
    {
        private readonly IClientService _clientService;

        public ClientProxy(ITransactionFactory transactionFactory, ITransactionService transactionService, IClientService clientService)
            : base(transactionFactory, transactionService)
        {
            _clientService = clientService;
        }

        public void Create(string name)
        {
            _clientService.Create(name);

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = $"Created client with name '{name}'";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);
        }

        public ICollection<Client> GetAll()
        {
            var clients = _clientService.GetAll();

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = "Retrieved all clients";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);

            return clients;
        }

        public Client? GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
