using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Proxies.Contracts
{
    public interface ITransferProxy
    {
        void Transfer(int senderId, int recipientId, decimal amount);
    }
}
