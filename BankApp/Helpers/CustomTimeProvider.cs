using BankApp.Helpers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Helpers
{
    public class CustomTimeProvider : ICustomTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
