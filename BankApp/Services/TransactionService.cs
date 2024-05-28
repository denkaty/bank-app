using BankApp.Entities;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void Add(Transaction transaction)
        {
            _transactionRepository.Add(transaction);
        }

        public ICollection<Transaction> GetAll()
        {
            return _transactionRepository.GetAll();
        }

    }
}
