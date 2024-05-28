using BankApp.Factories.TransactionFactory;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Proxies.Base;
using BankApp.Proxies.Contracts;
using BankApp.Repositories;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies
{
    public class DepositProxy : BaseProxy, IDepositProxy
    {
        private readonly IDepositService _depositService;

        public DepositProxy(ITransactionFactory transactionFactory, ITransactionService transactionService, IDepositService depositService)
            : base(transactionFactory, transactionService)
        {
            _depositService = depositService;
        }

        public void Deposit(int clientId, decimal amount)
        {
            _depositService.Deposit(clientId, amount);

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = $"Deposited {amount} lv. for client with ID '{clientId}'";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);
        }
    }
}
