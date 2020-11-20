using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.Returns;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementPortal.Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<List<OrderInfo>> GetAllListItems()
        {
            var ordersInfos = await this.DbSet.Include(o => o.OrderedByCustomer)
                .Select(order => new OrderInfo()
                {
                    Id = order.Id,
                    CreationDate = order.CreationDate,
                    LastUpdateDate = order.LastUpdateDate,
                    OrderedByCustomerId = order.OrderedByCustomerId,
                    OrderedByCustomerFullName = $"{order.OrderedByCustomer.Name} {order.OrderedByCustomer.LastName}",
                    Price = order.Price,
                    StatusId = order.StatusId
                }).ToListAsync();

            return ordersInfos;
        }

        public new async Task<Order> GetByIdAsync(Guid id, bool trackChanges)
        {
            var address = trackChanges
                ? await this.DbSet.Include(c => c.OrderedByCustomer)
                    .Include(o => o.Status)
                    .FirstOrDefaultAsync(a => a.Id == id)
                : await this.DbSet.Include(c => c.OrderedByCustomer)
                    .Include(o => o.Status)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(a => a.Id == id);

            return address;
        }
    }
}
