using System;
using System.Collections.Generic;
using System.Linq;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = base.FindAll(false)
                .OrderBy(c => c.LastName)
                .ToList();

            return customers;
        }

        public Customer GetCustomerById(Guid id, bool trackChanges)
        {
            var customer = base.DbSet.FirstOrDefault(c => c.Id == id);

            return customer;
        }
    }
}
