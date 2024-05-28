using BankApp.ChainOfResponsibilities;
using BankApp.ChainOfResponsibilities.ApplyBonusBalance;
using BankApp.ChainOfResponsibilities.Balance;
using BankApp.ChainOfResponsibilities.CheckWithdrawals;
using BankApp.ChainOfResponsibilities.Clients;
using BankApp.ChainOfResponsibilities.Contracts;
using BankApp.ChainOfResponsibilities.Contracts.ApplyBonusBalance;
using BankApp.ChainOfResponsibilities.Contracts.Balance;
using BankApp.ChainOfResponsibilities.Contracts.CheckWithdrawals;
using BankApp.ChainOfResponsibilities.Contracts.Clients;
using BankApp.ChainOfResponsibilities.Contracts.CreateClient;
using BankApp.ChainOfResponsibilities.Contracts.Deposit;
using BankApp.ChainOfResponsibilities.Contracts.Transactions;
using BankApp.ChainOfResponsibilities.Contracts.Transfer;
using BankApp.ChainOfResponsibilities.Contracts.Withdraw;
using BankApp.ChainOfResponsibilities.CreateClient;
using BankApp.ChainOfResponsibilities.Deposit;
using BankApp.ChainOfResponsibilities.Transactions;
using BankApp.ChainOfResponsibilities.Transfer;
using BankApp.ChainOfResponsibilities.Withdraw;
using BankApp.Commands;
using BankApp.Commands.Contracts;
using BankApp.Engines;
using BankApp.Engines.Contracts;
using BankApp.Factories.ClientFactory;
using BankApp.Factories.CommandFactory;
using BankApp.Factories.IteratorFactory;
using BankApp.Factories.TaxCalculationStrategyFactory;
using BankApp.Factories.TaxCalculationStrategyFactory.Contracts;
using BankApp.Factories.TransactionFactory;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Factories.WithdrawalClientTypeStrategyFactory;
using BankApp.Factories.WithdrawalClientTypeStrategyFactory.Contracts;
using BankApp.Helpers;
using BankApp.Helpers.Contracts;
using BankApp.Iterators;
using BankApp.Iterators.Contracts;
using BankApp.Jobs;
using BankApp.Jobs.Contracts;
using BankApp.LogProviders;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies;
using BankApp.Proxies.Contracts;
using BankApp.Repositories;
using BankApp.Repositories.Contracts;
using BankApp.Services;
using BankApp.Services.Contracts;
using BankApp.Strategies.TaxCalculationStrategies;
using BankApp.Strategies.TaxCalculationStrategies.Contracts;
using BankApp.Strategies.WithdrawalClientTypeStrategies;
using BankApp.Strategies.WithdrawalClientTypeStrategies.Contracts;
using BankApp.Visitors;
using BankApp.Visitors.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace BankApp.Configurators
{
    public class ServiceConfigurator
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<ILogProvider, ConsoleLogProvider>()
                    .AddTransient<ICustomTimeProvider, CustomTimeProvider>();

            services.AddSingleton<IBankEngine, BankEngine>();

            services.AddSingleton<IClientRepository, ClientRepository>();
            services.AddSingleton<ITransactionRepository, TransactionRepository>();

            services.AddScoped<ICommandExecutor, CommandExecutor>()
                    .AddScoped<ICreateClientCommand, CreateClientCommand>()
                    .AddScoped<IDepositCommand, DepositCommand>()
                    .AddScoped<IWithdrawCommand, WithdrawCommand>()
                    .AddScoped<IBalanceCommand, BalanceCommand>()
                    .AddScoped<ITransferCommand, TransferCommand>()
                    .AddScoped<IClientsCommand, ClientsCommand>()
                    .AddScoped<ITransactionsCommand, TransactionsCommand>()
                    .AddScoped<ICheckWithdrawalsCommand, CheckWithdrawalsCommand>()
                    .AddScoped<IApplyBonusBalanceCommand, ApplyBonusBalanceCommand>();

            services.AddScoped<ICommandFactory, CommandFactory>()
                    .AddSingleton<IClientFactory, ClientFactory>()
                    .AddScoped<ITaxCalculationStrategyFactory, TaxCalculationStrategyFactory>()
                    .AddScoped<ITransactionFactory, TransactionFactory>()
                    .AddScoped<IClientIteratorFactory, ClientIteratorFactory>()
                    .AddScoped<IWithdrawalClientTypeStrategyFactory, WithdrawalClientTypeStrategyFactory>();

            services.AddScoped<IStandardTaxCalculationStrategy, StandardTaxCalculationStrategy>()
                    .AddScoped<IPremiumTaxCalculationStrategy, PremiumTaxCalculationStrategy>()
                    .AddScoped<IPlatinumTaxCalculationStrategy, PlatinumTaxCalculationStrategy>()
                    .AddScoped<IStandardWithdrawalClientTypeStrategy, StandardWithdrawalClientTypeStrategy>()
                    .AddScoped<IPremiumWithdrawalClientTypeStrategy, PremiumWithdrawalClientTypeStrategy>()
                    .AddScoped<IPlatinumWithdrawalClientTypeStrategy, PlatinumWithdrawalClientTypeStrategy>();

            services.AddScoped<IClientService, ClientService>()
                    .AddScoped<IDepositService, DepositService>()
                    .AddScoped<IWithdrawService, WithdrawService>()
                    .AddScoped<IBalanceService, BalanceService>()
                    .AddScoped<ITransferService, TransferService>()
                    .AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<IBalanceProxy, BalanceProxy>()
                    .AddScoped<IClientProxy, ClientProxy>()
                    .AddScoped<IDepositProxy, DepositProxy>()
                    .AddScoped<ITransferProxy, TransferProxy>()
                    .AddScoped<IWithdrawProxy, WithdrawProxy>()
                    .AddScoped<ITransactionProxy, TransactionProxy>();

            services.AddScoped<IBankFacade, BankFacade>();

            services.AddScoped<IClientIterator, ClientIterator>();

            services.AddScoped<IBalanceIncreaseVisitor, BalanceIncreaseVisitor>()
                    .AddScoped<IWithdrawalCountVisitor, WithdrawalCountVisitor>();

            services.AddScoped<IApplyBonusBalanceJob, ApplyBonusBalanceJob>()
                    .AddScoped<ICheckWithdrawalsCountJob, CheckWithdrawalsCountJob>();

            services.AddScoped<IBalanceArgumentCountValidationHandler, BalanceArgumentCountValidationHandler>()
                    .AddScoped<IBalanceClientIdValidationHandler, BalanceClientIdValidationHandler>()
                    .AddScoped<IBalanceValidationHandler, BalanceValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<IBalanceArgumentCountValidationHandler>();
                        var clientIdHandler = provider.GetRequiredService<IBalanceClientIdValidationHandler>();

                        argumentCountHandler.SetNext(clientIdHandler);

                        return new BalanceValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<IClientsArgumentCountValidationHandler, ClientsArgumentCountValidationHandler>()
                    .AddScoped<IClientsValidationHandler, ClientsValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<IClientsArgumentCountValidationHandler>();

                        return new ClientsValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<ICreateClientArgumentCountValidationHandler, CreateClientArgumentCountValidationHandler>()
                    .AddScoped<ICreateClientNameValidationHandler, CreateClientNameValidationHandler>()
                    .AddScoped<ICreateClientValidationHandler, CreateClientValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<ICreateClientArgumentCountValidationHandler>();
                        var nameHandler = provider.GetRequiredService<ICreateClientNameValidationHandler>();

                        argumentCountHandler.SetNext(nameHandler);

                        return new CreateClientValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<IDepositArgumentCountValidationHandler, DepositArgumentCountValidationHandler>()
                    .AddScoped<IDepositClientIdValidationHandler, DepositClientIdValidationHandler>()
                    .AddScoped<IDepositAmountValidationHandler, DepositAmountValidationHandler>()
                    .AddScoped<IDepositValidationHandler, DepositValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<IDepositArgumentCountValidationHandler>();
                        var clientIdHandler = provider.GetRequiredService<IDepositClientIdValidationHandler>();
                        var amountHandler = provider.GetRequiredService<IDepositAmountValidationHandler>();

                        argumentCountHandler.SetNext(clientIdHandler).SetNext(amountHandler);

                        return new DepositValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<ITransactionsArgumentCountValidationHandler, TransactionsArgumentCountValidationHandler>()
                    .AddScoped<ITransactionsValidationHandler, TransactionsValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<ITransactionsArgumentCountValidationHandler>();

                        return new TransactionsValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<ITransferArgumentCountValidationHandler, TransferArgumentCountValidationHandler>()
                    .AddScoped<ITransferSenderIdValidationHandler, TransferSenderIdValidationHandler>()
                    .AddScoped<ITransferRecipientIdValidationHandler, TransferRecipientIdValidationHandler>()
                    .AddScoped<ITransferAmountValidationHandler, TransferAmountValidationHandler>()
                    .AddScoped<ITransferValidationHandler, TransferValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<ITransferArgumentCountValidationHandler>();
                        var senderIdHandler = provider.GetRequiredService<ITransferSenderIdValidationHandler>();
                        var recipientIdHandler = provider.GetRequiredService<ITransferRecipientIdValidationHandler>();
                        var amountHandler = provider.GetRequiredService<ITransferAmountValidationHandler>();

                        argumentCountHandler.SetNext(senderIdHandler).SetNext(recipientIdHandler).SetNext(amountHandler);

                        return new TransferValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<IWithdrawArgumentCountValidationHandler, WithdrawArgumentCountValidationHandler>()
                    .AddScoped<IWithdrawClientIdValidationHandler, WithdrawClientIdValidationHandler>()
                    .AddScoped<IWithdrawAmountValidationHandler, WithdrawAmountValidationHandler>()
                    .AddScoped<IWithdrawValidationHandler, WithdrawValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<IWithdrawArgumentCountValidationHandler>();
                        var clientIdHandler = provider.GetRequiredService<IWithdrawClientIdValidationHandler>();
                        var amountHandler = provider.GetRequiredService<IWithdrawAmountValidationHandler>();

                        argumentCountHandler.SetNext(clientIdHandler).SetNext(amountHandler);

                        return new WithdrawValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<ICheckWithdrawalsArgumentCountValidationHandler, CheckWithdrawalsArgumentCountValidationHandler>()
                    .AddScoped<ICheckWithdrawalsValidationHandler, CheckWithdrawalsValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<ICheckWithdrawalsArgumentCountValidationHandler>();

                        return new CheckWithdrawalsValidationHandler(argumentCountHandler);
                    });

            services.AddScoped<IApplyBonusBalanceArgumentCountValidationHandler, ApplyBonusBalanceArgumentCountValidationHandler>()
                    .AddScoped<IApplyBonusBalanceValidationHandler, ApplyBonusBalanceValidationHandler>(provider =>
                    {
                        var argumentCountHandler = provider.GetRequiredService<IApplyBonusBalanceArgumentCountValidationHandler>();

                        return new ApplyBonusBalanceValidationHandler(argumentCountHandler);
                    });

        }
    }
}
