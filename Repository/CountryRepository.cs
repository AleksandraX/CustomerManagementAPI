using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;


namespace CustomerManagementPortal.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {

        public CountryRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
