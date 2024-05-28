using BankApp.Entities;
using BankApp.Iterators.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories.IteratorFactory
{
    public interface IClientIteratorFactory
    {
        IIterator<Client> GetInstance(ICollection<Client> clients);
    }
}
