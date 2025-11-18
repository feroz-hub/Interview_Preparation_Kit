namespace DIP.Domain.Models;


public sealed class Customer(string id, string name, string email)
{
    public string Id { get; } = id ?? throw new ArgumentNullException(nameof(id));
    public string Name { get; } = name ?? throw new ArgumentNullException(nameof(name));
    public string Email { get; } = email ?? throw new ArgumentNullException(nameof(email));

    public override string ToString() => $"{Name} <{Email}> (#{Id})";
}
