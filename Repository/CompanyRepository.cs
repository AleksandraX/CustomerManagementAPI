using System.Collections.Generic;
using System.Linq;
using Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges)
                .OrderBy(c => c.Name)
                .ToList();
    }
}
