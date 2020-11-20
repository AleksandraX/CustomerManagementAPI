using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.Returns;

namespace CustomerManagementPortal.Contracts
{
    public interface IOrderRepository :IRepositoryBase<Order>
    {
        public Task<List<OrderInfo>> GetAllListItems();


    }
}
