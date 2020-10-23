using System;
using System.Collections.Generic;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Contracts
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        public IEnumerable<Customer> GetAllCustomers();

        public Customer GetCustomerById(Guid id, bool trackChanges);

        public void CreateCustomer(Customer customer);

        public IEnumerable<Customer> GetByIds(IEnumerable<Guid> ids, bool trackChanges);

        public void DeleteCustomer(Customer customer);
    }
}
