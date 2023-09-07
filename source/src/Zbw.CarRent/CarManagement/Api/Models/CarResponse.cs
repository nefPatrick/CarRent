using Zbw.CarRent.CarManagement.Domain;

namespace Zbw.CarRent.CarManagement.Api.Models {
  public record CarResponse(Guid Id, string IdentificationNumber, string Model,
    string Type, CarClass CarClass);
}
