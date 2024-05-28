using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Iterators.Contracts
{
    public interface IIterator<T> where T : class
    {
        bool HasNext();
        T Next();
    }
}
