using Microsoft.AspNetCore.Mvc;
using Zbw.CarRent.CustomerManagement.Api.Models;
using Zbw.CarRent.CustomerManagement.Domain;

namespace Zbw.CarRent.CustomerManagement.Api {

  [Route("api/customers")]
  [ApiController]
  public class CustomerController : ControllerBase {

    private readonly ICustomerRepository _repository;

    public CustomerController(ICustomerRepository repository) {
      ArgumentNullException.ThrowIfNull(repository, nameof(repository));
      _repository = repository;
    }

    // GET: api/<CustomerController>
    [HttpGet]
    public IActionResult Get() {
      var allCustomers = _repository.GetAll();
      var customerResponses = allCustomers.Select(MapToResponse);
      return Ok(customerResponses);
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id) {
      var customer = _repository.Get(id);
      if (customer == null) return NotFound();

      return Ok(MapToResponse(customer));
    }

    // POST api/<CustomerController>
    [HttpPost]
    public IActionResult Post([FromBody] CustomerRequest value) {
      var newCustomer = new Customer() {
        Id = value.Id,
        CustomerNumber = value.CustomerNumber,
        LastName = value.LastName,
        FirstName = value.FirstName,
        Address = value.Address,
      };

      _repository.Add(newCustomer);
      return Ok();
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] CustomerRequest value) {
      var customer = _repository.Get(id);
      if (customer == null) return NotFound();

      customer.FirstName = value.FirstName;
      customer.LastName = value.LastName;
      customer.Address = value.Address;

      _repository.Update(customer);
      return Ok();
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id) {
      var customer = _repository.Get(id);
      if (customer == null) return NotFound();

      _repository.Remove(id);
      return Ok();
    }

    public static CustomerResponse MapToResponse(Customer customer) {
      return new CustomerResponse(customer.Id, customer.CustomerNumber,
        customer.LastName, customer.FirstName, customer.Address);
    }
  }
}
