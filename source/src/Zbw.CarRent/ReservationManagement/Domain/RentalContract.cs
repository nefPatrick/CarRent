namespace Zbw.CarRent.ReservationManagement.Domain {
  public class RentalContract {

    public Guid Id { get; set; }

    public string ContractNumber { get; set; }

    public Guid ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    public DateTime CreateDateTime { get; set; }

  }
}
