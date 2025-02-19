﻿using System.Threading.Tasks;
using CustomerManagementPortal.Contracts;
using CustomerManagementPortal.Entities;

namespace CustomerManagementPortal.Repository
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;
        private ICustomerRepository _customerRepository;
        private IAddressRepository _addressRepository;
        private IOrderRepository _orderRepository;
        private IOrderStatusRepository _orderStatusRepository;
        private ICountryRepository _countryRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public ICompanyRepository Company => _companyRepository ??= new CompanyRepository(_repositoryContext);

        public IEmployeeRepository Employee => _employeeRepository ??= new EmployeeRepository(_repositoryContext);

        public ICustomerRepository Customer => _customerRepository ??= new CustomerRepository(_repositoryContext);

        public IAddressRepository Address => _addressRepository ??= new AddressRepository(_repositoryContext);

        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_repositoryContext);

        public IOrderStatusRepository OrderStatuses => _orderStatusRepository ??= new OrderStatusRepository(_repositoryContext);

        public ICountryRepository Country => _countryRepository ??= new CountryRepository(_repositoryContext);
       

    public void Save() => _repositoryContext.SaveChanges();

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
