using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Repository
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
    }
}
