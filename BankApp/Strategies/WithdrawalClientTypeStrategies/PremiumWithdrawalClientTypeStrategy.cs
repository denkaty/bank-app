using BankApp.Enums;
using BankApp.Strategies.WithdrawalClientTypeStrategies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Strategies.WithdrawalClientTypeStrategies
{
    public class PremiumWithdrawalClientTypeStrategy : IPremiumWithdrawalClientTypeStrategy
    {
        public ClientType GetClientType()
        {
            return ClientType.Premium;
        }
    }
}
