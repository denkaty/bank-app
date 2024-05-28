using BankApp.Entities;
using BankApp.Iterators;
using BankApp.Iterators.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories.IteratorFactory
{
    public class ClientIteratorFactory : IClientIteratorFactory
    {
        public IIterator<Client> GetInstance(ICollection<Client> clients)
        {
            return new ClientIterator(clients);
        }
    }
}
