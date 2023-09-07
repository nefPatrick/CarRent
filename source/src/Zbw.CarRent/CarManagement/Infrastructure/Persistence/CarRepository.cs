using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.General.Infrastructure.Persistence;

namespace Zbw.CarRent.CarManagement.Infrastructure.Persistence {
  public class CarRepository : IRepository<Car> {

    private readonly CarRentContext _context;

    public CarRepository(CarRentContext context) {
      _context = context;
    }

    public void Add(Car value) {
      _context.Add(value);
      _context.SaveChanges();
    }

    public Car? Get(Guid id) {
      return _context.Cars.Find(id);
    }

    public IEnumerable<Car> GetAll() {
      return _context.Cars.ToList();
    }

    public void Remove(Guid id) {
      var carToRemove = _context.Cars.Find(id);
      if (carToRemove == null) return;

      _context.Cars.Remove(carToRemove);
      _context.SaveChanges();
    }

    public void Update(Car value) {
      _context.Cars.Update(value);
      _context.SaveChanges();
    }
  }
}
