using System;
using System.Collections.Generic;
using System.Linq;
using CustomerManagementPortal.Api.ModelBinders;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.DataTransferredObjects;
using CustomerManagementPortal.Entities.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementPortal.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomersController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllCustomers()
        {
            var customers = _repository.Customer.GetAllCustomers();

            if (!customers.Any())
            {
                return NotFound("Non of customers exist.");
            }

            return Ok(customers);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = _repository.Customer.GetCustomerById(id, false);

            if (customer == null)
            {
                return NotFound($"Customer with id: {id} does not exist.");
            }

            return Ok(customer);
        }

        [HttpPost("[action]")]
        public IActionResult CreateCustomer([FromBody] CustomerForCreationDto customerToCreate)
        {
            if (customerToCreate == null)
            {
                _logger.LogError("Customer object for creation is null");
                return BadRequest("Customer for create cannot be empty.");
            }

            var customerEntity = new Customer()
            {
                Name = customerToCreate.Name,
                LastName = customerToCreate.LastName,
                Age = customerToCreate.Age,
                Email = customerToCreate.Email,
                Gender = customerToCreate.Gender,
                PhoneNumber = customerToCreate.PhoneNumber,
                Address = customerToCreate.Address
            };

            this._repository.Customer.CreateCustomer(customerEntity);
            this._repository.Save();

            return CreatedAtRoute("GetCustomerById", new {id = customerEntity.Id}, customerEntity);
        }

        [HttpGet("[action]/{ids}")]
        public IActionResult GetManyCustomers([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var idsList = ids.ToList();
            if (!idsList.Any())
            {
                _logger.LogError("Parameter is null");
                return BadRequest("Parameter with ids is empty");
            }

            var customerEntities = _repository.Customer.GetByIds(idsList, false);
            if (idsList.Count() != customerEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            return Ok(customerEntities);
        }

        [HttpPut("[action/{id}]")]
        public IActionResult UpdateCustomer(Guid id, [FromBody] CustomerForUpdateDto customerForUpdate)
        {
            if (customerForUpdate == null)
            {
                _logger.LogError("Customer object sent from client is null.");
                return BadRequest("Customer object is null");
            }

            var customer = _repository.Customer.GetCustomerById(id, true);

            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            customer.Name = customerForUpdate.Name;
            customer.LastName = customerForUpdate.LastName;
            customer.Age = customerForUpdate.Age;
            customer.Gender = customerForUpdate.Gender;
            customer.Email = customerForUpdate.Email;
            customer.PhoneNumber = customerForUpdate.PhoneNumber;
            customer.Address = customerForUpdate.Address;

            _repository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(Guid id)
        {
            var customer = _repository.Customer.GetCustomerById(id, false);

            if (customer == null)
            {
                _logger.LogInfo($"Customer with id: {id} doesn't exist in the database.");
                return NotFound();
            }

            _repository.Customer.DeleteCustomer(customer);
            _repository.Save();

            return NoContent();
        }
    }
}
