using BankApp.Factories.WithdrawalClientTypeStrategyFactory.Contracts;
using BankApp.Strategies.WithdrawalClientTypeStrategies.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories.WithdrawalClientTypeStrategyFactory
{
    public class WithdrawalClientTypeStrategyFactory : IWithdrawalClientTypeStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public WithdrawalClientTypeStrategyFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IWithdrawalClientTypeStrategy GetInstance(int withdrawals)
        {
            IWithdrawalClientTypeStrategy strategy = null;

            if (withdrawals <= 10)
            {
                strategy = _serviceProvider.GetRequiredService<IStandardWithdrawalClientTypeStrategy>();
            }
            else if (withdrawals <= 20)
            {
                strategy = _serviceProvider.GetRequiredService<IPremiumWithdrawalClientTypeStrategy>();
            }
            else
            {
                strategy = _serviceProvider.GetRequiredService<IPlatinumWithdrawalClientTypeStrategy>();
            }

            return strategy;
        }

    }
}
