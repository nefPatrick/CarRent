using Zbw.CarRent.ReservationManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Api.Models {
  public record RentalContractResponse(Guid Id, Reservation Reservation, DateTime CreateDateTime, string ContractNumber);
}
