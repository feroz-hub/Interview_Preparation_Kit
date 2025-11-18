namespace OCP.Domain.Models
{
    public sealed class Account
    {
        public string Name { get; }
        public string AccountType { get; }  // e.g., "Savings", "FixedDeposit", "Current"
        public decimal Balance { get; }

        public Account(string name, string accountType, decimal balance)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            AccountType = accountType ?? throw new ArgumentNullException(nameof(accountType));
            Balance = balance;
        }
    }

}
