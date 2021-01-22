
using CustomerManagementPortal.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerManagementPortal.Contracts
{
    public interface IAddressRepository : IRepositoryBase<Address>
    {
        Task<List<Address>> GetAllFullAddresses();
        Task<Address> GetByIdAsync(Guid id);
    }
}
