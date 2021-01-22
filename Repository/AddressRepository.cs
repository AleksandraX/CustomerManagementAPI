using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementPortal.Repository
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

            
        }

        public async Task<List<Address>> GetAllFullAddresses()
        {
            var fullAdresses = base.DbSet.Include(address => address.Country).AsNoTracking();

            return await fullAdresses.ToListAsync();
        }

        public async Task<Address> GetByIdAsync(Guid id)
        {
            var address = await this.DbSet.Include(address => address.Country)
                .FirstOrDefaultAsync(adress => adress.Id == id);

            return address;
        }

    }
}
