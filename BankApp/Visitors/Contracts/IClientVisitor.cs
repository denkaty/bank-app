using BankApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Visitors.Contracts
{
    public interface IClientVisitor
    {
        void Visit(Client client);
    }
}
