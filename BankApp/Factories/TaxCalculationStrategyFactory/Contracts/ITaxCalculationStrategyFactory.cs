using BankApp.Enums;
using BankApp.Strategies.TaxCalculationStrategies.Contracts;

namespace BankApp.Factories.TaxCalculationStrategyFactory.Contracts;

public interface ITaxCalculationStrategyFactory
{
    ITaxCalculationStrategy GetTaxCalculationStrategy(ClientType clientType);
}