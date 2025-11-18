using OCP.Domain.Interfaces;
using OCP.Domain.Models;


namespace OCP.Infrastructure.Calculators
{

    public sealed class SavingsInterestCalculator : IInterestCalculator
    {
        public string AccountTypeKey => "Savings";
        public decimal Calculate(Account account) => account.Balance * 0.03m; // 3%
    }

}
