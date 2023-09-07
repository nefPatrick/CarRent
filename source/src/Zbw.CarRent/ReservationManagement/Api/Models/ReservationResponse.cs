using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.ReservationManagement.Api.Models {
  public record ReservationResponse(Guid Id, DateTime ReservationDate,
    int AmountOfDays, decimal TotalCosts, Car Car, Customer Customer);
}
