namespace Zbw.CarRent.CustomerManagement.Api.Models {
  public record CustomerRequest(
    Guid Id,
    int CustomerNumber,
    string LastName,
    string FirstName,
    string? Address
  );
}
