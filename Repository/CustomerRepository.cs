using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;
using CustomerManagementPortal.Entities.RequestFeatures;
using CustomerManagementPortal.Entities.Returns;
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
            var customers = await base.DbSet.Include(c => c.Address)
                .OrderBy(c => c.LastName)
                .ToListAsync();

            return customers;
        }


        public async Task<IEnumerable<CustomerListItem>> GetAllListItems()
        {
            var customers = await base.DbSet.Include(c => c.Address)
                .Select(c => new CustomerListItem()
                {
                    Id = c.Id,
                    Name = c.Name,
                    LastName = c.LastName,
                    Age = c.Age,
                    City = c.Address.City,
                    Email = c.Email,
                    Gender = c.Gender,
                    PhoneNumber = c.PhoneNumber
                })
                .OrderBy(c => c.LastName)
                .ToListAsync();

            return customers;
        }

        public async Task<PagedList<CustomerListItem>> GetPageOfListItems(CustomersParameters customerParameters)
        {
            var customers = await this.GetAllListItems();

            return PagedList<CustomerListItem>.ToPagedList(customers, customerParameters.PageNumber, customerParameters.PageSize);
        }

        public async Task<List<CustomerPersonalData>> GetCustomersPersonalDataByAddressId(Guid addressId)
        {
            var customersData = await this.DbSet
                .Where(c => c.AddressId == addressId)
                .Select(c => new CustomerPersonalData()
                {
                    Id = c.Id,
                    Name = c.Name,
                    LastName = c.LastName,
                    Age = c.Age,
                    Email = c.Email,
                    Gender = c.Gender,
                    PhoneNumber = c.PhoneNumber
                })
                .OrderBy(c => c.LastName)
                .ToListAsync();

            return customersData;
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
