using Zbw.CarRent.CustomerManagement.Domain;
using Zbw.CarRent.General.Infrastructure.Persistence;

namespace Zbw.CarRent.CustomerManagement.Infrastructure.Persistence {
  public class CustomerRepository : IRepository<Customer> {

    private readonly CarRentContext _context;

    public CustomerRepository(CarRentContext context) {
      _context = context;
    }

    public void Add(Customer value) {
      _context.Add(value);
      _context.SaveChanges();
    }

    public Customer? Get(Guid id) {
      return _context.Customers.Find(id);
    }

    public IEnumerable<Customer> GetAll() {
      return _context.Customers.ToList();
    }

    public void Remove(Guid id) {
      var customerToRemove = _context.Customers.Find(id);
      if (customerToRemove == null) return;
      _context.Customers.Remove(customerToRemove);
      _context.SaveChanges();
    }

    public void Update(Customer value) {
      _context.Customers.Update(value);
      _context.SaveChanges();
    }
  }
}
