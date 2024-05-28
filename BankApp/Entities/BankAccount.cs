namespace BankApp.Entities
{
    public class BankAccount
    {
        private decimal balance;

        private int withdrawals;

        public decimal Balance => balance;
        public int Withdrawals => withdrawals;

        public BankAccount()
        {
            balance = 0;
            withdrawals = 0;
        }

        public void Deposit(decimal amount)
        {
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds.");
            }

            balance -= amount;
            withdrawals += 1;
        }

        public void ResetWithdrawalsCount()
        {
            withdrawals = 0;
        }

        public override string ToString()
        {
            return $"Balance: {Balance}; Withdrawals: {Withdrawals}";
        }
    }
}
