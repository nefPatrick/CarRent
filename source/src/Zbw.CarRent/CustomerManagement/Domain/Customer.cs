namespace Zbw.CarRent.CustomerManagement.Domain {
  public class Customer {

    public Guid Id { get; set; }
    public int CustomerNumber { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? Address { get; set; }

  }
}
