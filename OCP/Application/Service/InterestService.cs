using OCP.Application.Resolver;
using OCP.Domain.Models;


namespace OCP.Application.Service
{

    public sealed class InterestService(IInterestCalculatorResolver resolver)
    {
        private readonly IInterestCalculatorResolver _resolver = resolver;

        public decimal ComputeInterest(Account account)
        {
            var calc = _resolver.Resolve(account.AccountType);
            return calc.Calculate(account);
        }
    }

}
