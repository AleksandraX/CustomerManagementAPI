using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.RequestFeatures;
using CustomerManagementPortal.Entities.Returns;

namespace CustomerManagementPortal.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Task<IEnumerable<Customer>> GetAllAsync();

        public void CreateCustomer(Customer customer);

        public Task<IEnumerable<Customer>> GetManyByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);
        Task<PagedList<CustomerListItem>> GetPageOfListItems(CustomersParameters customerParameters);

        public Task<IEnumerable<CustomerListItem>> GetAllListItems();

        public void DeleteCustomer(Customer customer);
    }
}
