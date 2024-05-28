using BankApp.Entities;
using BankApp.Repositories.Contracts;

namespace BankApp.Repositories
{
    public class ClientRepository : IClientRepository
    {
        //private static readonly object _lock = new object();
        //private static ClientRepository _instance = null;
        //private static Dictionary<int, Client> _clients;

        //private ClientRepository() { }

        //public static ClientRepository GetInstance
        //{
        //    get
        //    {
        //        lock (_lock)
        //        {
        //            if (_instance == null)
        //            {
        //                _instance = new ClientRepository();
        //                _clients = new Dictionary<int, Client>();
        //            }
        
        //            return _instance;
        
        //        }
        //    }
        //}

        private readonly Dictionary<int, Client> _clients;

        public ClientRepository()
        {
            _clients = new Dictionary<int, Client>();
        }

        public Client? GetById(int id)
        {
            if (!_clients.ContainsKey(id)) { return null; }

            Client client = _clients[id];
            return client;
        }

        public ICollection<Client> GetAll()
        {
            return _clients.Values;
        }

        public void Add(Client client)
        {
            _clients.Add(client.Id, client);
        }

    }
}
