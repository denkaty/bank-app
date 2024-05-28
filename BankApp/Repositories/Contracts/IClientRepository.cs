using BankApp.Entities;

namespace BankApp.Repositories.Contracts
{
    public interface IClientRepository
    {
        Client? GetById(int id);

        ICollection<Client> GetAll();

        void Add(Client client);
    }
}
