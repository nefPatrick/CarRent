namespace Zbw.CarRent.CustomerManagement.Api.Models {
  public record CustomerResponse(
    Guid Id,
    int CustomerNumber,
    string LastName,
    string FirstName,
    string? Address
  );
}
