using BankApp.ChainOfResponsibilities.Contracts;
using BankApp.LogProviders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities
{
    public abstract class Handler : IHandler
    {
        protected IHandler Successor;

        public IHandler SetNext(IHandler successor)
        {
            Successor = successor;
            return successor;
        }

        public abstract bool HandleRequest(ICollection<string> arguments);
    }
}
