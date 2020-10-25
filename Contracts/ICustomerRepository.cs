using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public Task<IEnumerable<Customer>> GetAllAsync();

        public Task<Customer> GetByIdAsync(Guid id, bool trackChanges);

        public void CreateCustomer(Customer customer);

        public Task<IEnumerable<Customer>> GetManyByIdsAsync(IEnumerable<Guid> ids, bool trackChanges);

        public void DeleteCustomer(Customer customer);
    }
}
