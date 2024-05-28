using BankApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies.Contracts
{
    public interface ITransactionProxy
    {
        void Add(Transaction transaction);
        ICollection<Transaction> GetAll();
    }
}
