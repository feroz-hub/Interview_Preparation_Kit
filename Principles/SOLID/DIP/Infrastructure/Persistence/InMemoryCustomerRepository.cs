using DIP.Domain.Interfaces;
using DIP.Domain.Models;

namespace DIP.Infrastructure.Persistence;


/// <summary>
/// Low-level detail: in-memory persistence for demo.
/// </summary>
public sealed class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> store = [];

    public void Add(Customer customer)
    {
        store.Add(customer);
        Console.WriteLine($"[Repo] Added: {customer}");
    }
}
