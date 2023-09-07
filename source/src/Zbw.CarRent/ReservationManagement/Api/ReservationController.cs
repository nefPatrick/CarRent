using Microsoft.AspNetCore.Mvc;
using Zbw.CarRent.General.Infrastructure.Persistence;
using Zbw.CarRent.ReservationManagement.Api.Models;
using Zbw.CarRent.ReservationManagement.Domain;
using Zbw.CarRent.ReservationManagement.Infrastructure.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zbw.CarRent.ReservationManagement.Api {
  [Route("api/[controller]")]
  [ApiController]
  public class ReservationController : ControllerBase {

    private readonly IRepository<Reservation> _repository;

    public ReservationController(IRepository<Reservation> repository) {
      _repository = repository;
    }

    // GET: api/<ReservationController>
    [HttpGet]
    public IActionResult Get() {
      var reservations = _repository.GetAll();
      return Ok(reservations.Select(MapToResponse));
    }

    // GET api/<ReservationController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) {
      var reservation = _repository.Get(id);
      if (reservation == null) return NotFound();

      return Ok(MapToResponse(reservation));
    }

    // POST api/<ReservationController>
    [HttpPost]
    public IActionResult Post([FromBody] ReservationRequest value) {
      var newReservation = new Reservation() {
        AmountOfDays = value.AmountOfDays,
        Car = value.Car,
        CarId = value.Car.Id,
        Id = value.Id,
        Customer = value.Customer,
        CustomerId = value.Customer.Id,
        ReservationDate = value.ReservationDate,
        TotalCosts = value.Car.CarClass.DailyFee * value.AmountOfDays
      };

      _repository.Add(newReservation);
      return Ok();
    }

    // PUT api/<ReservationController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] ReservationRequest value) {
      var reservation = _repository.Get(id);
      if (reservation == null) return NotFound();

      reservation.ReservationDate = value.ReservationDate;
      reservation.Customer = value.Customer;
      reservation.CustomerId = value.Customer.Id;
      reservation.Car = value.Car;
      reservation.CarId = value.Car.Id;
      reservation.AmountOfDays = value.AmountOfDays;

      _repository.Update(reservation);
      return Ok();
    }

    // DELETE api/<ReservationController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      var reservation = _repository.Get(id);
      if (reservation == null) return NotFound();

      _repository.Remove(id);
      return Ok();
    }

    private static ReservationResponse MapToResponse(Reservation reservation) {
      return new ReservationResponse(reservation.Id, reservation.ReservationDate, reservation.AmountOfDays,
        reservation.TotalCosts, reservation.Car, reservation.Customer);
    }
  }
}
