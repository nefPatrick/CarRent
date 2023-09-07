using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Domain {
  public class Reservation {

    public Guid Id { get; set; }

    public DateTime ReservationDate { get; set; }

    public int AmountOfDays { get; set; }

    public decimal TotalCosts { get; set; }

    public Guid CarId { get; set; }

    public Car Car { get; set; }

    public Guid CustomerId { get; set; }

    public Customer Customer { get; set; }
    

  }
}
