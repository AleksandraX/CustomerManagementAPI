

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.Enums;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NSwag.Annotations;

namespace CustomerManagementPortal.Api.Controllers
{
    [ApiController]
    [Route("api/orderStatuses")]
    public class OrderStatusesController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public OrderStatusesController(IRepositoryManager repositoryManager, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }


        [HttpGet("[action]")]
        [SwaggerResponse(typeof(List<OrderStatus>))]
        public async Task<IActionResult> GetAll()
        {
            var statuses = await this._repositoryManager.OrderStatuses.FindAll(false).ToListAsync();

            return Ok(statuses);
        }

        [HttpGet("[action]/{id}")]
        [SwaggerResponse(typeof(OrderStatus))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var status = await this._repositoryManager.OrderStatuses.GetByIdAsync(id, false);

            return Ok(status);
        }

        
    }
}
