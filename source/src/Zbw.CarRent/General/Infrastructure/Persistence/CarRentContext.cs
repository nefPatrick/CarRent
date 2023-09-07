using Microsoft.EntityFrameworkCore;
using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.CustomerManagement.Domain;
using Zbw.CarRent.ReservationManagement.Domain;

namespace Zbw.CarRent.General.Infrastructure.Persistence {
  public class CarRentContext : DbContext {

    public CarRentContext(DbContextOptions<CarRentContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }

    public DbSet<CarClass> CarClasses { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Reservation> Reservations { get; set; }

    public DbSet<RentalContract> RentalContracts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<CarClass>().Property(p => p.DailyFee).HasPrecision(8, 2);
      modelBuilder.Entity<Reservation>().Property(p => p.TotalCosts).HasPrecision(8, 2);
    }

  }
}
