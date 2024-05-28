using BankApp.Entities;
using BankApp.Factories.WithdrawalClientTypeStrategyFactory.Contracts;
using BankApp.Strategies.WithdrawalClientTypeStrategies.Contracts;
using BankApp.Visitors.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Visitors
{
    public class WithdrawalCountVisitor : IWithdrawalCountVisitor
    {
        private readonly IWithdrawalClientTypeStrategyFactory _withdrawalClientTypeStrategyFactory;

        public WithdrawalCountVisitor(IWithdrawalClientTypeStrategyFactory withdrawalClientTypeStrategyFactory)
        {
            _withdrawalClientTypeStrategyFactory = withdrawalClientTypeStrategyFactory;
        }

        public void Visit(Client client)
        {
            int withdrawals = client.Account.Withdrawals;

            IWithdrawalClientTypeStrategy withdrawalClientTypeStrategy = _withdrawalClientTypeStrategyFactory.GetInstance(withdrawals);

            client.Type = withdrawalClientTypeStrategy.GetClientType();

            client.Account.ResetWithdrawalsCount();
        }
    }
}
