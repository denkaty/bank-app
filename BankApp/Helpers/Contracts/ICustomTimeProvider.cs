using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Helpers.Contracts
{
    public interface ICustomTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
