using DIP.Domain.Models;

namespace DIP.Domain.Interfaces;


/// <summary>
/// Abstraction for customer persistence.
/// </summary>
public interface ICustomerRepository
{
    void Add(Customer customer);
}
