using OCP.Domain.Interfaces;
using OCP.Domain.Models;


namespace OCP.Infrastructure.Calculators
{

    public sealed class CurrentInterestCalculator : IInterestCalculator
    {
        public string AccountTypeKey => "Current";
        public decimal Calculate(Account account) => account.Balance * 0.07m; // 7%
    }

}
