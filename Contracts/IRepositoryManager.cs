using System.Threading.Tasks;

namespace CustomerManagementPortal.Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        ICustomerRepository Customer { get; }
        IAddressRepository Address { get; }
        void Save();
        Task SaveAsync();
    }
}
