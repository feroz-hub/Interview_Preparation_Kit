using OCP.Application.Resolver;
using OCP.Domain.Interfaces;


namespace OCP.Infrastructure.Resolver
{

    /// <summary>
    /// Turns many strategies into a keyed lookup. New strategies are injected—no modification needed.
    /// </summary>
    public sealed class InterestCalculatorResolver(IEnumerable<IInterestCalculator> calculators) : IInterestCalculatorResolver
    {
        private readonly IReadOnlyDictionary<string, IInterestCalculator> _map = calculators.ToDictionary(
                c => c.AccountTypeKey,
                c => c,
                StringComparer.OrdinalIgnoreCase
            );

        public IInterestCalculator Resolve(string accountTypeKey)
        {
            if (string.IsNullOrWhiteSpace(accountTypeKey))
                throw new ArgumentException("Account type key is required.", nameof(accountTypeKey));

            if (_map.TryGetValue(accountTypeKey, out var calc))
                return calc;

            throw new InvalidOperationException(
                $"No interest calculator registered for account type '{accountTypeKey}'. " +
                $"Add a class implementing IInterestCalculator to extend behavior."
            );
        }
    }

}
