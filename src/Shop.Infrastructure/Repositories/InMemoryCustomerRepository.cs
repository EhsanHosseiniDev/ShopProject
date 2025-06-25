using Shop.Domain.Aggregators.Users;
using Shop.Domain.Common;

public class InMemoryCustomerRepository : ICustomerRepository
{
    private readonly List<Customer> _customer = new()
    {
        new(){Id=GlobalStatic.CustomerId,Name="customer #1"}
    };

    public void Add(Customer entity)
    {
        var existing = _customer.FirstOrDefault(o => o.Id == entity.Id);
        if (existing != null)
        {
            _customer.Remove(existing);
        }
        _customer.Add(entity);
    }

    public Customer? Find(Guid entityId) => _customer.FirstOrDefault();

}
