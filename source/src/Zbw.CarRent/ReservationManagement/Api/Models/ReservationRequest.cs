using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Api.Models {
  public record ReservationRequest(Guid Id, DateTime ReservationDate,
    int AmountOfDays, Car Car, Customer Customer);
}
