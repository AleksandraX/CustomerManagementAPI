
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using CustomerManagementPortal.Api.ModelBinders;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.DataTransferredObjects;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.Returns;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        //[SwaggerResponse(typeof(List<Country>)]
        private async Task<IActionResult> SeedAllCountries()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://countries-cities.p.rapidapi.com/location/country/list"),
                Headers =
                    {
                        { "x-rapidapi-key", "4290992691mshd2665330073ebefp16d367jsnd0f459008da4" },
                        { "x-rapidapi-host", "countries-cities.p.rapidapi.com" },
                    },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                CountryReponse countryReponse = JsonConvert.DeserializeObject<CountryReponse>(body);

                foreach(var countryProp in countryReponse.countries.GetType().GetProperties())
                {

                    var country = new Country()
                    {
                        Name = countryProp.GetValue(countryReponse.countries).ToString(),
                        Code = countryProp.Name
                    };

                    this._repository.Country.Create(country);
                }

                this._repository.Save();

                
                return Ok(countryReponse);
            }
        }


        [HttpGet("[action]")]
        [SwaggerResponse(typeof(List<Address>))]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await this._repository.Address.GetAllFullAddresses();

            return Ok(addresses);
        }

        [HttpGet("[action]")]
        [SwaggerResponse(typeof(List<Country>))]
        public async Task<IActionResult> GetAllCountries()
        {
            var countries = await this._repository.Country.FindAll(false).ToListAsync();

            return Ok(countries);
        }



        [HttpGet("[action]/{id}")]
        [SwaggerResponse(typeof(Address))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var addresses = await this._repository.Address.GetByIdAsync(id, false);

            return Ok(addresses);
        }

        [HttpGet("[action]/{addressId}")]
        [SwaggerResponse(typeof(List<AddressWithResidents>))]
        public async Task<IActionResult> GetAddressWithResidents(Guid addressId)
        {
            var address = await this._repository.Address.GetByIdAsync(addressId);

            if (address == null)
            {
                return NotFound("This address does not exist");
            }

            var residents = await this._repository.Customer.GetCustomersPersonalDataByAddressId(addressId);

            var addressWithResidents = new AddressWithResidents
            {
                Id = address.Id,
                City = address.City,
                Country = address.Country.Name,
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
                CountryId = addressForCreationDto.CountryId,
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
