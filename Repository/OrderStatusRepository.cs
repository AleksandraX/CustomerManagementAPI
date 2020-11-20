using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Enums;

namespace CustomerManagementPortal.Repository
{
    public class OrderStatusRepository : RepositoryBase<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
    }
}
