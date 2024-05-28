using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.ChainOfResponsibilities.Contracts
{
    public interface IHandler
    {
        IHandler SetNext(IHandler successor);
        bool HandleRequest(ICollection<string> arguments);
    }
}
