using BankApp.Strategies.WithdrawalClientTypeStrategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Factories.WithdrawalClientTypeStrategyFactory.Contracts
{
    public interface IWithdrawalClientTypeStrategyFactory
    {
        IWithdrawalClientTypeStrategy GetInstance(int withdrawals);
    }
}
