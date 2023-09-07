using Zbw.CarRent.General.Infrastructure.Persistence;
using Zbw.CarRent.ReservationManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Infrastructure.Persistence {
  public class RentalContractRepository : IRepository<RentalContract> {

    private readonly CarRentContext _context;

    public RentalContractRepository(CarRentContext context) {
      _context = context;
    }

    public void Add(RentalContract value) {
      _context.Add(value);
      _context.SaveChanges();
    }

    public RentalContract? Get(Guid id) {
      return _context.RentalContracts.Find(id);
    }

    public IEnumerable<RentalContract> GetAll() {
      return _context.RentalContracts.ToList();
    }

    public void Remove(Guid id) {
      var contractToRemove = _context.RentalContracts.Find(id);
      if (contractToRemove == null) return;

      _context.RentalContracts.Remove(contractToRemove);
      _context.SaveChanges();
    }

    public void Update(RentalContract value) {
      _context.RentalContracts.Update(value);
      _context.SaveChanges();
    }
  }
}
