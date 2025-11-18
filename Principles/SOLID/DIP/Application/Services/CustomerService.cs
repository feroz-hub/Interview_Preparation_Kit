using DIP.Domain.Interfaces;
using DIP.Domain.Models;

namespace DIP.Application.Services;


/// <summary>
/// High-level module: orchestrates a use-case.
/// Depends on abstractions only (DIP).
/// </summary>
public sealed class CustomerService(ICustomerRepository repo, ILogger logger)
{
    public void Register(Customer customer)
    {
        repo.Add(customer);
        logger.Log($"Customer registered: {customer}");
    }
}
