using OCP.Domain.Interfaces;
using OCP.Domain.Models;


namespace OCP.Infrastructure.Calculators
{

    public sealed class FixedDepositInterestCalculator : IInterestCalculator
    {
        public string AccountTypeKey => "FixedDeposit";
        public decimal Calculate(Account account) => account.Balance * 0.05m; // 5%
    }

}
