using BankApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories.TransactionFactory.Contracts
{
    public interface ITransactionFactory
    {
        Transaction GetInstance(string type, string description);
    }
}
