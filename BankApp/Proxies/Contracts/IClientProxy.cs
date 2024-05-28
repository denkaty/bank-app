using BankApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies.Contracts
{
    public interface IClientProxy
    {
        void Create(string name);

        Client? GetById(int id);

        ICollection<Client> GetAll();
    }
}
