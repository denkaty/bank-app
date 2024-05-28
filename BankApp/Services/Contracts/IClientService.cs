using BankApp.Entities;
using BankApp.Iterators.Contracts;

namespace BankApp.Services.Contracts
{
    public interface IClientService
    {
        void Create(string name);

        Client? GetById(int id);

        ICollection<Client> GetAll();

        IIterator<Client> GetIterator();
    }
}
