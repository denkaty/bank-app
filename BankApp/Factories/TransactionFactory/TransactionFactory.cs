using BankApp.Entities;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories.TransactionFactory
{
    public class TransactionFactory : ITransactionFactory
    {
        private readonly ICustomTimeProvider _timeProvider;
        private int _id;

        public TransactionFactory(ICustomTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
            _id = 1;
        }

        public Transaction GetInstance(string type, string description)
        {
            var transaction = new Transaction
            {
                Id = _id,
                Type = type,
                Timestamp = _timeProvider.UtcNow,
                Description = description
            };

            _id++;

            return transaction;
        }

    }
}
