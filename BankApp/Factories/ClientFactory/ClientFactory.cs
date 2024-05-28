using BankApp.Entities;

namespace BankApp.Factories.ClientFactory
{
    public class ClientFactory : IClientFactory
    {
        private int _id;

        public ClientFactory()
        {
            _id = 1;
        }

        public Client GetInstance(string name)
        {
            Client client = new Client(_id, name);

            _id++;

            return client;
        }

        public Client GetInstance(int id, string name)
        {
            Client client = new Client(id, name);

            return client;
        }
    }
}
