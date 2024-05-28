using BankApp.Entities;
using BankApp.Iterators.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Iterators
{
    public class ClientIterator : IClientIterator
    {

        private readonly ICollection<Client> _clients;
        private int _index;

        public ClientIterator(ICollection<Client> clients)
        {
            _clients = clients;
            _index = 0;
        }

        public bool HasNext()
        {
            return _index + 1 <= _clients.Count;
        }

        public Client Next()
        {
            return _clients.ElementAt(_index++);
        }
    }
}
