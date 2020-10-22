using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext repositoryContext;
        private ICompanyRepository companyRepository;
        private IEmployeeRepository employeeRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public ICompanyRepository Company => companyRepository ??= new CompanyRepository(repositoryContext);

        public IEmployeeRepository Employee => employeeRepository ??= new EmployeeRepository(repositoryContext);

        public void Save() => repositoryContext.SaveChanges();
    }
}
