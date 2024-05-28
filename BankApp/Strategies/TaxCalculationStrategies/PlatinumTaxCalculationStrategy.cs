using BankApp.Strategies.TaxCalculationStrategies.Contracts;

namespace BankApp.Strategies.TaxCalculationStrategies
{
    public class PlatinumTaxCalculationStrategy : IPlatinumTaxCalculationStrategy
    {
        public decimal CalculateTax(decimal withdrawalAmount)
        {
            if (withdrawalAmount <= 100)
            {
                return withdrawalAmount * 0.01m;
            }
            else if (withdrawalAmount <= 1000)
            {
                return withdrawalAmount * 0.03m;
            }
            else
            {
                return withdrawalAmount * 0.05m;
            }
        }
    }
}
