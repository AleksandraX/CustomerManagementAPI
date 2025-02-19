﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementPortal.Api.ActionFilters;
using CustomerManagementPortal.Api.ModelBinders;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.DataTransferredObjects;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.RequestFeatures;
using CustomerManagementPortal.Entities.Returns;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NSwag.Annotations;

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
        [SwaggerResponse(typeof(List<Customer>))]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _repository.Customer.GetAllAsync();

            if (!customers.Any())
            {
                return NotFound("Non of customers exist.");
            }

            return Ok(customers);
        }



        [HttpGet("[action]")]
        [SwaggerResponse(typeof(PagedList<Customer>))]
        public async Task<IActionResult> GetPageOfListItems([FromQuery] CustomersParameters customerParameters)
        {
            var customers = await _repository.Customer.GetPageOfListItems(customerParameters);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(customers.MetaData));

            return Ok(customers);
        }

        [HttpGet("[action]")]
        [SwaggerResponse(typeof(List<CustomerListItem>))]
        public async Task<IActionResult> GetAllListItems()
        {
            var customers = await _repository.Customer.GetAllListItems();

            if (!customers.Any())
            {
                return NotFound("Non of customers exist.");
            }

            return Ok(customers);
        }

        [HttpGet("[action]/{id}")]
        [ServiceFilter(typeof(ValidateCustomerExistAttribute))]
        [SwaggerResponse(typeof(Customer))]
        public IActionResult GetById(Guid id)
        {
            var customer = HttpContext.Items["customer"] as Customer;

            return Ok(customer);
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCustomer([FromBody] CustomerForCreationDto customerToCreate)
        {
            var customerEntity = new Customer()
            {
                Name = customerToCreate.Name,
                LastName = customerToCreate.LastName,
                Age = customerToCreate.Age,
                Email = customerToCreate.Email,
                Gender = customerToCreate.Gender,
                PhoneNumber = customerToCreate.PhoneNumber,
                Address = new Address()
                {
                    CountryId = customerToCreate.CountryId,
                    City = customerToCreate.City,
                    Street = customerToCreate.Street,
                    ZipCode = customerToCreate.ZipCode
                }
            };

            this._repository.Customer.CreateCustomer(customerEntity);
            await this._repository.SaveAsync();

            return CreatedAtRoute("GetCustomerById", new {id = customerEntity.Id}, customerEntity);
        }

        [HttpGet("[action]/{ids}")]
        [SwaggerResponse(typeof(List<Customer>))]
        public async Task<IActionResult> GetMany([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            var idsList = ids.ToList();
            if (!idsList.Any())
            {
                _logger.LogError("Parameter is null");
                return BadRequest("Parameter with ids is empty");
            }

            var customerEntities = await _repository.Customer.GetManyByIdsAsync(idsList, false);
            if (idsList.Count() != customerEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }

            return Ok(customerEntities);
        }



        [HttpGet("[action]/{addressId}")]
        [SwaggerResponse(typeof(List<CustomerPersonalData>))]
        public async Task<IActionResult> GetCustomersByAddress(Guid addressId)
        {
            var address = await this._repository.Address.GetByIdAsync(addressId, false);

            if (address == null)
            {
                return NotFound("This address does not exist");
            }

            var customerList = await this._repository.Customer.GetCustomersPersonalDataByAddressId(addressId);

            return Ok(customerList);
        }


        [HttpPut("[action]/{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateCustomerExistAttribute))]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] CustomerForUpdateDto customerForUpdate)
        {
            var customer = HttpContext.Items["customer"] as Customer;

            customer.Name = customerForUpdate.Name;
            customer.LastName = customerForUpdate.LastName;
            customer.Age = customerForUpdate.Age;
            customer.Gender = customerForUpdate.Gender;
            customer.Email = customerForUpdate.Email;
            customer.PhoneNumber = customerForUpdate.PhoneNumber;
            customer.Address = customerForUpdate.Address;

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        [ServiceFilter(typeof(ValidateCustomerExistAttribute))]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = HttpContext.Items["customer"] as Customer;

            _repository.Customer.DeleteCustomer(customer);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
