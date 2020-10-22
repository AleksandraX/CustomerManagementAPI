
using System.Collections.Generic;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
