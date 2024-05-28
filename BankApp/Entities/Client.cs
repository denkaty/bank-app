using BankApp.Enums;
using BankApp.Visitors.Contracts;

namespace BankApp.Entities
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ClientType Type { get; set; }
        public BankAccount Account { get; private set; }

        public Client(int id, string name)
        {
            Id = id;
            Name = name;
            Type = ClientType.Standard;
            Account = new BankAccount();
        }

        public void AcceptVisitor(IClientVisitor visitor)
        {
           visitor.Visit(this); 
        }

        public override string ToString()
        {
            return $"Id: {Id}; Name: {Name}; Type: {Type}; BankAccount: {Account}";
        }
    }
}
