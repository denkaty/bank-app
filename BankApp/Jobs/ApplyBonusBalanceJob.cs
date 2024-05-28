using BankApp.Entities;
using BankApp.Iterators.Contracts;
using BankApp.Jobs.Contracts;
using BankApp.Services.Contracts;
using BankApp.Visitors.Contracts;

namespace BankApp.Jobs
{
    public class ApplyBonusBalanceJob : IApplyBonusBalanceJob
    {
        private readonly IClientService _clientService;
        private readonly IBalanceIncreaseVisitor _balanceIncreaseVisitor;

        public ApplyBonusBalanceJob(IClientService clientService, IBalanceIncreaseVisitor balanceIncreaseVisitor)
        {
            _clientService = clientService;
            _balanceIncreaseVisitor = balanceIncreaseVisitor;
        }

        public void Execute()
        {
            IIterator<Client> iterator = _clientService.GetIterator();

            while(iterator.HasNext())
            {
                Client client = iterator.Next();
                _balanceIncreaseVisitor.Visit(client);
            }
        }

    }
}
