using Microsoft.AspNetCore.Mvc;
using Zbw.CarRent.CarManagement.Api.Models;
using Zbw.CarRent.CarManagement.Domain;
using Zbw.CarRent.General.Infrastructure.Persistence;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zbw.CarRent.CarManagement.Api {
  [Route("api/carClasses")]
  [ApiController]
  public class CarClassController : ControllerBase {

    private readonly IRepository<CarClass> _repository;

    public CarClassController(IRepository<CarClass> repository) {
      _repository = repository;
    }

    // GET: api/<CarClassController>
    [HttpGet]
    public IActionResult Get() {
      var allCarClasses = _repository.GetAll();
      return Ok(allCarClasses.Select(MapToResponse));
    }

    // GET api/<CarClassController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) {
      var carClass = _repository.Get(id);
      if (carClass == null) return NotFound();
      
      return Ok(MapToResponse(carClass));
    }

    // POST api/<CarClassController>
    [HttpPost]
    public IActionResult Post([FromBody] CarClassRequest value) {
      var newCarClass = new CarClass() {
        Id = value.Id,
        Name = value.Name,
        DailyFee = value.DailyFee
      };

      _repository.Add(newCarClass);
      return Ok();
    }

    // PUT api/<CarClassController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] CarClassRequest value) {
      var carClass = _repository.Get(id);
      if (carClass == null) return NotFound();

      carClass.Name = value.Name;
      carClass.DailyFee = value.DailyFee;

      _repository.Update(carClass);
      return Ok();
    }

    // DELETE api/<CarClassController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      var carClass = _repository.Get(id);
      if (carClass == null) return NotFound();

      _repository.Remove(id);
      return Ok();
    }

    private static CarClassResponse MapToResponse(CarClass carClass) {
      return new CarClassResponse(carClass.Id, carClass.Name, carClass.DailyFee);
    }
  }
}
