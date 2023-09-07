using Microsoft.AspNetCore.Mvc;
using Zbw.CarRent.CarManagement.Api.Models;
using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.General.Infrastructure.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zbw.CarRent.CarManagement.Api {
  [Route("api/[controller]")]
  [ApiController]
  public class CarController : ControllerBase {

    private readonly IRepository<Car> _repository;

    public CarController(IRepository<Car> repository) {
      _repository = repository;
    }

    // GET: api/<CarController>
    [HttpGet]
    public IActionResult Get() {
      var allCars = _repository.GetAll();
      return Ok(allCars.Select(MapToResponse));
    }

    // GET api/<CarController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) {
      var car = _repository.Get(id);
      if (car == null) return NotFound();

      return Ok(MapToResponse(car));
    }

    // POST api/<CarController>
    [HttpPost]
    public IActionResult Post([FromBody] CarRequest value) {
      var newCar = new Car() {
        CarClass = value.CarClass,
        CarClassId = value.CarClass.Id,
        Id = value.Id,
        IdentificationNumber = value.IdentificationNumber,
        Model = value.Model,
        Type = value.Type
      };

      _repository.Add(newCar);
      return Ok();
    }

    // PUT api/<CarController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] CarRequest value) {
      var car = _repository.Get(id);
      if (car == null) return NotFound();

      car.Model = value.Model;
      car.CarClass = value.CarClass;
      car.CarClassId = value.CarClass.Id;
      car.IdentificationNumber = value.IdentificationNumber;
      car.Type = value.Type;

      _repository.Update(car);
      return Ok();
    }

    // DELETE api/<CarController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      var car = _repository.Get(id);
      if (car == null) return NotFound();
      _repository.Remove(id);
      return Ok();

    }

    private static CarResponse MapToResponse(Car car) {
      return new CarResponse(car.Id, car.IdentificationNumber, car.Model,
        car.Type, car.CarClass);
    }
  }
}
