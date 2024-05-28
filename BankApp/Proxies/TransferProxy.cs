using BankApp.Factories.TransactionFactory;
using BankApp.Factories.TransactionFactory.Contracts;
using BankApp.Proxies.Base;
using BankApp.Proxies.Contracts;
using BankApp.Repositories;
using BankApp.Repositories.Contracts;
using BankApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies
{
    public class TransferProxy : BaseProxy, ITransferProxy
    {
        private readonly ITransferService _transferService;

        public TransferProxy(ITransactionFactory transactionFactory, ITransactionService transactionService, ITransferService transferService)
            : base(transactionFactory, transactionService)
        {
            _transferService = transferService;
        }

        public void Transfer(int senderId, int recipientId, decimal amount)
        {
            _transferService.Transfer(senderId, recipientId, amount);

            var type = MethodBase.GetCurrentMethod()!.Name;
            var description = $"Transferred {amount} lv. from client with ID '{senderId}' to client with ID '{recipientId}'";
            var transaction = TransactionFactory.GetInstance(type, description);
            TransactionService.Add(transaction);
        }
    }
}
