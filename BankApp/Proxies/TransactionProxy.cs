using BankApp.Entities;
using BankApp.Factories.TransactionFactory;
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
    public class TransactionProxy : BaseProxy, ITransactionProxy
    {
        public TransactionProxy(ITransactionFactory transactionFactory, ITransactionService transactionService)
            : base(transactionFactory, transactionService)
        {
        }

        public void Add(Transaction transaction)
        {
            TransactionService.Add(transaction);
        }

        public ICollection<Transaction> GetAll()
        {
            var transactions = TransactionService.GetAll();

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = "Retrieved all transactions";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);

            return transactions;
        }

    }
}
