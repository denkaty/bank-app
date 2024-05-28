namespace BankApp.Strategies.TaxCalculationStrategies.Contracts;

public interface ITaxCalculationStrategy
{
    decimal CalculateTax(decimal withdrawalAmount);
}