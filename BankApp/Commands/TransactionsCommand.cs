using BankApp.ChainOfResponsibilities.Contracts.Transactions;
using BankApp.Commands.Base;
using BankApp.Commands.Contracts;
using BankApp.Entities;
using BankApp.LogProviders.Contracts;
using BankApp.Proxies.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Commands
{
    public class TransactionsCommand : BaseCommand, ITransactionsCommand
    {
        private readonly ITransactionsValidationHandler _validationHandler;

        public TransactionsCommand(ILogProvider logger, IBankFacade bankFacade, ITransactionsValidationHandler validationHandler)
            : base(logger, bankFacade)
        {
            _validationHandler = validationHandler;
        }

        public void Execute(ICollection<string> arguments)
        {
            if (!_validationHandler.HandleRequest(arguments)) { return; }

            try
            {
                ICollection<Transaction> transactions = BankFacade.GetAllTransactions();

                if (transactions.Count == 0)
                {
                    Logger.Log("No transactions found.");
                    return;
                }

                foreach (Transaction transaction in transactions)
                {
                    Logger.Log(transaction.ToString());
                }

            }
            catch (Exception ex)
            {
                Logger.Log($"Failed to list transactions: {ex.Message}");
            }
        }
    }
}
