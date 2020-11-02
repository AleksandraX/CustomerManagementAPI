
using System;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> GetAll()
        {
            var addresses = await this._repository.Address.FindAll(false).ToListAsync();

            return Ok(addresses);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var addresses = await this._repository.Address.GetByIdAsync(id, false);

            return Ok(addresses);
        }

    }
}
