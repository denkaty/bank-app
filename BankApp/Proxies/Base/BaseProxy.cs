using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.LogProviders.Contracts;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies.Base
{
    public abstract class BaseProxy
    {
        protected readonly ITransactionFactory TransactionFactory;
        protected readonly ITransactionService TransactionService;

        protected BaseProxy(ITransactionFactory transactionFactory, ITransactionService transactionService)
        {
            TransactionFactory = transactionFactory;
            TransactionService = transactionService;
        }
    }
}
