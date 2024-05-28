namespace BankApp.Services.Contracts
{
    public interface ITransferService
    {
        void Transfer(int senderId, int recipientId, decimal amount);
    }
}
