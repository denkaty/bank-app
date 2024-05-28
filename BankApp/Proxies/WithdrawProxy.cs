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
    public class WithdrawProxy : BaseProxy, IWithdrawProxy
    {
        private readonly IWithdrawService _withdrawService;

        public WithdrawProxy(ITransactionFactory transactionFactory, ITransactionService transactionService, IWithdrawService withdrawService)
            : base(transactionFactory, transactionService)
        {
            _withdrawService = withdrawService;
        }

        public decimal Withdraw(int clientId, decimal amount)
        {
            decimal withdrawal = _withdrawService.Withdraw(clientId, amount);

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = $"Withdrawn {amount} for client with ID '{clientId}'";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);

            return withdrawal;
        }

    }
}
