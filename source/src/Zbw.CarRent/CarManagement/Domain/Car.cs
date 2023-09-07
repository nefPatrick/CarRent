namespace Zbw.CarRent.CarManagement.Domain {
  public class Car {

    public Guid Id { get; set; }
    public string IdentificationNumber { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }

    public Guid CarClassId { get; set; }
    public CarClass CarClass { get; set;}

  }
}
