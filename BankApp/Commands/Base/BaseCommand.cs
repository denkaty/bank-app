using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands.Base
{
    public abstract class BaseCommand
    {
        protected readonly ILogProvider Logger;
        protected readonly IBankFacade BankFacade;

        protected BaseCommand(ILogProvider logger, IBankFacade bankFacade)
        {
            Logger = logger;
            BankFacade = bankFacade;
        }
    }
}
