using BankApp.Configurators;
using BankApp.Engines.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace BankApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run();
        }

        private static void Run()
        {
            IHost host = Host
               .CreateDefaultBuilder()
               .ConfigureServices(ServiceConfigurator.Configure)
               .Build();

            IServiceProvider serviceProvider = host
                .Services
                .CreateScope()
                .ServiceProvider;

            IBankEngine bankEngine = serviceProvider
                .GetRequiredService<IBankEngine>();

            bankEngine.Run();
        }

    }
}
