using Zbw.CarRent.General.Infrastructure.Persistence;
using Zbw.CarRent.ReservationManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Infrastructure.Persistence {
  public class ReservationRepository : IRepository<Reservation> {

    private readonly CarRentContext _context;

    public ReservationRepository(CarRentContext context) {
      _context = context;
    }

    public void Add(Reservation value) {
      _context.Add(value);
      _context.SaveChanges();
    }

    public Reservation? Get(Guid id) {
      return _context.Reservations.Find(id);
    }

    public IEnumerable<Reservation> GetAll() {
      return _context.Reservations.ToList();
    }

    public void Remove(Guid id) {
      var reservationToRemove = _context.Reservations.Find(id);
      if (reservationToRemove == null) return;

      _context.Reservations.Remove(reservationToRemove);
      _context.SaveChanges();
    }

    public void Update(Reservation value) {
      _context.Reservations.Update(value);
      _context.SaveChanges();
    }
  }
}
