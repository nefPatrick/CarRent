using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.General.Infrastructure.Persistence;

namespace Zbw.CarRent.CarManagement.Infrastructure.Persistence {
  public class CarClassRepository : IRepository<CarClass> {

    private readonly CarRentContext _context;

    public CarClassRepository(CarRentContext context) {
      _context = context;
    }

    public void Add(CarClass value) {
      _context.Add(value);
      _context.SaveChanges();
    }

    public CarClass? Get(Guid id) {
      return _context.CarClasses.Find(id);
    }

    public IEnumerable<CarClass> GetAll() {
      return _context.CarClasses.ToList();
    }

    public void Remove(Guid id) {
      var carClasstoRemove = _context.CarClasses.Find(id);
      if (carClasstoRemove == null) return;

      _context.CarClasses.Remove(carClasstoRemove);
      _context.SaveChanges();
    }

    public void Update(CarClass value) {
      _context.CarClasses.Update(value);
      _context.SaveChanges();
    }
  }
}
