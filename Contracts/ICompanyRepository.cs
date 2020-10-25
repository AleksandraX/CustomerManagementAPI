using System.Collections.Generic;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
