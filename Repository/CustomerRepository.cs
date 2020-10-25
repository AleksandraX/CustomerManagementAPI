using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementPortal.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await base.FindAll(false)
                .OrderBy(c => c.LastName)
                .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetByIdAsync(Guid id, bool trackChanges)
        {
            var customer = await base.DbSet.FirstOrDefaultAsync(c => c.Id == id);

            return customer;
        }

        public void CreateCustomer(Customer customer)
        {
            base.Create(customer);
        }

        public async Task<IEnumerable<Customer>> GetManyByIdsAsync(IEnumerable<Guid> ids, bool trackChanges)
        {
            return await base.FindByCondition(c => ids.Contains(c.Id), trackChanges)
                .ToListAsync();
        }

        public void DeleteCustomer(Customer customer)
        {
            base.Delete(customer);
        }
    }
}
