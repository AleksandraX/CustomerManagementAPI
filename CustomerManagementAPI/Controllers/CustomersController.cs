using System;
using System.Linq;
using CustomerManagementPortal.Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementPortal.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CustomersController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
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
    }
}
