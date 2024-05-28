using BankApp.ChainOfResponsibilities.Contracts.Clients;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.Entities;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;

namespace BankApp.Commands;

public class ClientsCommand : BaseCommand, IClientsCommand
{
    private readonly IClientsValidationHandler _validationHandler;

    public ClientsCommand(ILogProvider logger, IBankFacade bankFacade, IClientsValidationHandler validationHandler)
        : base(logger, bankFacade)
    {
        _validationHandler = validationHandler;
    }

    public void Execute(ICollection<string> arguments)
    {
        if (!_validationHandler.HandleRequest(arguments)) { return; }

        try
        {
            ICollection<Client> clients = BankFacade.GetAllClients();

            if (clients.Count == 0)
            {
                Logger.Log("No clients found.");
                return;
            }

            foreach (Client client in clients)
            {
                Logger.Log(client.ToString());
            }

        }
        catch (Exception ex)
        {
            Logger.Log($"Failed to list clients: {ex.Message}");
        }
    }
}