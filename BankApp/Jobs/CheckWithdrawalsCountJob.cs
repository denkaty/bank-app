using BankApp.Entities;
using BankApp.Iterators.Contracts;
using BankApp.Jobs.Contracts;
using BankApp.Services.Contracts;
using BankApp.Visitors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Jobs
{
    public class CheckWithdrawalsCountJob : ICheckWithdrawalsCountJob
    {
        private readonly IClientService _clientService;
        private readonly IWithdrawalCountVisitor _withdrawalCountVisitor;

        public CheckWithdrawalsCountJob(IClientService clientService, IWithdrawalCountVisitor withdrawalCountVisitor)
        {
            _clientService = clientService;
            _withdrawalCountVisitor = withdrawalCountVisitor;
        }

        public void Execute()
        {
            IIterator<Client> iterator = _clientService.GetIterator();

            while (iterator.HasNext())
            {
                Client client = iterator.Next();
                _withdrawalCountVisitor.Visit(client);
            }
        }
    }
}
