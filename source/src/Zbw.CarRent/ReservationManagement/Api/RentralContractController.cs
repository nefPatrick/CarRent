using Microsoft.AspNetCore.Mvc;
using Zbw.CarRent.General.Infrastructure.Persistence;
using Zbw.CarRent.ReservationManagement.Api.Models;
using Zbw.CarRent.ReservationManagement.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zbw.CarRent.ReservationManagement.Api {
  [Route("api/rentralContracts")]
  [ApiController]
  public class RentralContractController : ControllerBase {

    private readonly IRepository<RentalContract> _repository;

    public RentralContractController(IRepository<RentalContract> repository) { _repository = repository; }

    // GET: api/<RentralContractController>
    [HttpGet]
    public IActionResult Get() {
      var allContracts = _repository.GetAll();
      return Ok(allContracts.Select(MapToResponse));
    }

    // GET api/<RentralContractController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) {
      var contract = _repository.Get(id);
      if (contract == null) return NotFound();
      return Ok(MapToResponse(contract));
    }

    // POST api/<RentralContractController>
    [HttpPost]
    public IActionResult Post([FromBody] RentalContractRequest value) {
      var newContract = new RentalContract() {
        ContractNumber = value.ContractNumber,
        CreateDateTime = value.CreateDateTime,
        Id = value.Id,
        Reservation = value.Reservation,
        ReservationId = value.Reservation.Id
      };

      _repository.Add(newContract);
      return Ok();
    }

    // PUT api/<RentralContractController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] RentalContractRequest value) {
      var contract = _repository.Get(id);
      if (contract == null) return NotFound();

      contract.ContractNumber = value.ContractNumber;
      contract.ReservationId = value.Reservation.Id;

      _repository.Update(contract);
      return Ok();
    }

    // DELETE api/<RentralContractController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      var contract = _repository.Get(id);
      if (contract == null) return NotFound();

      _repository.Remove(id);
      return Ok();
    }

    private static RentalContractResponse MapToResponse(RentalContract rentalContract) {
      return new RentalContractResponse(rentalContract.Id, rentalContract.Reservation,
        rentalContract.CreateDateTime, rentalContract.ContractNumber);
    }
  }
}
