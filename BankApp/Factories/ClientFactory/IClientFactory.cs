using BankApp.Entities;

namespace BankApp.Factories.ClientFactory
{
    public interface IClientFactory
    {
        Client GetInstance(string name);
        Client GetInstance(int id, string name);
    }
}
