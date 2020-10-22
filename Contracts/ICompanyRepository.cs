
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
