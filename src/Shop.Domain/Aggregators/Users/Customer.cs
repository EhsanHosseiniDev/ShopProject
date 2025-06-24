using System;

namespace Shop.Domain.Aggregators.Users;

public class Customer
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public CustomerLevel CustomerLevel { get; set; }
}
