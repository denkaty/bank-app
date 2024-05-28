using BankApp.Enums;
using BankApp.Factories.TaxCalculationStrategyFactory.Contracts;
using BankApp.Strategies.TaxCalculationStrategies.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Factories.TaxCalculationStrategyFactory;

public class TaxCalculationStrategyFactory : ITaxCalculationStrategyFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<ClientType, Type> _strategyMap;

    public TaxCalculationStrategyFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _strategyMap = new Dictionary<ClientType, Type>
        {
            { ClientType.Standard, typeof(IStandardTaxCalculationStrategy) },
            { ClientType.Premium, typeof(IPremiumTaxCalculationStrategy) },
            { ClientType.Platinum, typeof(IPlatinumTaxCalculationStrategy) }
        };
    }

    public ITaxCalculationStrategy GetTaxCalculationStrategy(ClientType clientType)
    {
        if (_strategyMap.TryGetValue(clientType, out var strategyType))
        {
            return (ITaxCalculationStrategy)_serviceProvider.GetRequiredService(strategyType);
        }

        throw new ArgumentException("Invalid client type.");
    }

}