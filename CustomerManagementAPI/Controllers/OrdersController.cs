using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.DataTransferredObjects;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.RequestFeatures;
using CustomerManagementPortal.Entities.Returns;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSwag.Annotations;

namespace CustomerManagementPortal.Api.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public OrdersController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("[action]")]
        [SwaggerResponse(typeof(List<OrderInfo>))]
        public async Task<IActionResult> GetAllListItems()
        {
            var orders = await this._repository.Orders.GetAllListItems();

            return Ok(orders);
        }


        [HttpGet("[action]/{id}")]
        [SwaggerResponse(typeof(Order))]
        public async Task<IActionResult> GetById(Guid id)
        {
            var order = await this._repository.Orders.GetByIdAsync(id, false);

            return Ok(order);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> ChangeOrderStatus([FromQuery] OrderStatusChangeParameters orderStatusChangeParameters)
        {
            var order = await this._repository.Orders.GetByIdAsync(orderStatusChangeParameters.OrderId, true);

            if (order == null)
            {
                return BadRequest("Cannot find the order.");
            }

            var orderStatus = await this._repository.OrderStatuses.GetByIdAsync(orderStatusChangeParameters.NewOrderStatusId, false);

            if (orderStatus == null)
            {
                return BadRequest("Order status does not exist.");
            }


            order.StatusId = orderStatusChangeParameters.NewOrderStatusId;
            order.LastUpdateDate = DateTime.Now;
            await this._repository.SaveAsync();

            return Ok();
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderForCreationDto orderForCreationDto )
        {
            var order = new Order();

            var orderStatus = await this._repository.OrderStatuses
                .FindByCondition(status => status.Name == "New", false).SingleAsync();

            if (orderStatus == null)
            {
                return BadRequest("Order status does not exist.");
            }

            var customer = await this._repository.Customer.GetByIdAsync(orderForCreationDto.OrderedByCustomerId, false);

            if (customer == null)
            {
                return BadRequest("Customer does not exist.");
            }

            order.StatusId = orderStatus.Id;
            order.CreationDate = DateTime.Now;
            order.OrderedByCustomerId = orderForCreationDto.OrderedByCustomerId;
            order.Price = orderForCreationDto.Price;

            this._repository.Orders.Create(order);
            await this._repository.SaveAsync();

            return Ok();
        }
    }
}
