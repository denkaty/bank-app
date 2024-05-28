using BankApp.Entities;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Proxies.Base;
using BankApp.Proxies.Contracts;
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
    public class BalanceProxy : BaseProxy, IBalanceProxy
    {
        private readonly IBalanceService _balanceService;

        public BalanceProxy(ITransactionFactory transactionFactory, ITransactionService transactionService, IBalanceService balanceService)
            : base(transactionFactory, transactionService)
        {
            _balanceService = balanceService;
        }

        public decimal GetBalance(int clientId)
        {
            var balance = _balanceService.GetBalance(clientId);

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = $"Retrieved balance for client with ID '{clientId}'";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);

            return balance;
        }
    }
}
