using BankApp.Entities;
using BankApp.Factories.ClientFactory;
using BankApp.Factories.IteratorFactory;
using BankApp.Iterators.Contracts;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;

namespace BankApp.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IClientFactory _clientFactory;
        private readonly IClientIteratorFactory _iteratorFactory;

        public ClientService(IClientRepository clientRepository, IClientFactory clientFactory, IClientIteratorFactory iteratorFactory)
        {
            _clientRepository = clientRepository;
            _clientFactory = clientFactory;
            _iteratorFactory = iteratorFactory;
        }

        public void Create(string name)
        {
            Client client = _clientFactory.GetInstance(name);

            _clientRepository.Add(client);
        }

        public Client? GetById(int id)
        {
            Client? client = _clientRepository.GetById(id);
            return client;
        }

        public ICollection<Client> GetAll()
        {
            ICollection<Client> clients = _clientRepository.GetAll();
            return clients;
        }

        public IIterator<Client> GetIterator()
        {
            ICollection<Client> clients = _clientRepository.GetAll();

            IIterator<Client> iterator = _iteratorFactory.GetInstance(clients);

            return iterator;
        }

    }
}
