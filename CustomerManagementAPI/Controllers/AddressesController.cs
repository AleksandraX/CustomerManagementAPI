
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementPortal.Api.ActionFilters;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.DataTransferredObjects;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.Returns;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;

namespace CustomerManagementPortal.Api.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase
    {
        public ILoggerManager Logger { get; }
        private readonly IRepositoryManager _repository;

        public AddressesController(IRepositoryManager repository, ILoggerManager logger)
        {
            Logger = logger;
            _repository = repository;
        }

        [HttpGet("[action]")]
        [SwaggerResponse(typeof(List<Address>))]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await this._repository.Address.FindAll(false).ToListAsync();

            return Ok(addresses);
        }

        [HttpGet("[action]/{id}")]
        [SwaggerResponse(typeof(Address))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var addresses = await this._repository.Address.GetByIdAsync(id, false);

            return Ok(addresses);
        }

        [HttpGet("[action]/{id}")]
        [SwaggerResponse(typeof(List<AddressWithResidents>))]
        public async Task<IActionResult> GetAddressWithResidents(Guid addressId)
        {
            var address = await this._repository.Address.GetByIdAsync(addressId, false);

            if (address == null)
            {
                return NotFound("This address does not exist");
            }

            var residents = await this._repository.Customer.GetCustomersPersonalDataByAddressId(addressId);

            var addressWithResidents = new AddressWithResidents
            {
                Id = address.Id,
                City = address.City,
                Country = address.Country,
                ZipCode = address.ZipCode,
                Street = address.Street,
                Residents = residents.Select(r => new CustomerContact()
                {
                    CustomerId = r.Id,
                    Name = r.Name,
                    LastName = r.LastName,
                    Email = r.Email,
                    PhoneNumber = r.PhoneNumber
                }).ToList()
            };


            return Ok(addressWithResidents);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] AddressForCreationDto addressForCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Object is invalid.");
            }

            var address = new Address()
            {
                Country = addressForCreationDto.Country,
                City = addressForCreationDto.City,
                ZipCode = addressForCreationDto.ZipCode,
                Street = addressForCreationDto.Street
            };

            this._repository.Address.Create(address);
            await this._repository.SaveAsync();

            return Ok();
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var address = await this._repository.Address.GetByIdAsync(id, false);

            if (address == null)
            {
                return NotFound("This address does not exist");
            }

            _repository.Address.Delete(address);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
