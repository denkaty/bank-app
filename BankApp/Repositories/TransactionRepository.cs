using BankApp.Entities;
using BankApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        //private static readonly object _lock = new object();
        //private static TransactionRepository _instance = null;
        //private static Dictionary<int, Transaction> _transactions;

        //private TransactionRepository() { }

        //public static TransactionRepository GetInstance
        //{
        //    get
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new TransactionRepository();
        //                _transactions = new Dictionary<int, Transaction>();
        //            }

        //            return _instance;

        //        }
        //    }
        //}

        private readonly Dictionary<int, Transaction> _transactions;

        public TransactionRepository()
        {
            _transactions = new Dictionary<int, Transaction>();
        }

        public void Add(Transaction transaction)
        {
            _transactions.Add(transaction.Id, transaction);
        }

        public ICollection<Transaction> GetAll()
        {
            return _transactions.Values;
        }
    }
}
