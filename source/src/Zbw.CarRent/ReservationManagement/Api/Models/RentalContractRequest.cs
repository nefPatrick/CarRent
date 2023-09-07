using Zbw.CarRent.ReservationManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Api.Models {
  public record RentalContractRequest(Guid Id, Reservation Reservation, DateTime CreateDateTime, string ContractNumber);
}
