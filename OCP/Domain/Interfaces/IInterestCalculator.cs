using OCP.Domain.Models;


namespace OCP.Domain.Interfaces
{
    /// <summary>Strategy contract: one implementation per account type.</summary>
    public interface IInterestCalculator
    {
        string AccountTypeKey { get; }      // e.g., "Savings"
        decimal Calculate(Account account); // pure business rule
    }

}
