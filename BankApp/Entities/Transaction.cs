namespace BankApp.Entities
{
    public class Transaction
    {
        public int Id;
        public string Type;
        public DateTime Timestamp;
        public string Description;

        public Transaction()
        {
        }

        public override string ToString()
        {
            return $"Id: {Id}; Type: {Type}; Timestamp: {Timestamp}; Description: {Description};";
        }
    }
}
