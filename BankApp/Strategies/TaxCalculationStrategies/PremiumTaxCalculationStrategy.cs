using BankApp.Strategies.TaxCalculationStrategies.Contracts;

namespace BankApp.Strategies.TaxCalculationStrategies
{
    public class PremiumTaxCalculationStrategy : IPremiumTaxCalculationStrategy
    {
        public decimal CalculateTax(decimal withdrawalAmount)
        {
            if (withdrawalAmount <= 100)
            {
                return withdrawalAmount * 0.02m;
            }
            else if (withdrawalAmount <= 1000)
            {
                return withdrawalAmount * 0.04m;
            }
            else
            {
                return withdrawalAmount * 0.08m;
            }
        }
    }
}
