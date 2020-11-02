﻿using System.Threading.Tasks;
using Contracts;
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
        public IAddressRepository _addressRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            this._repositoryContext = repositoryContext;
        }

        public ICompanyRepository Company => _companyRepository ??= new CompanyRepository(_repositoryContext);

        public IEmployeeRepository Employee => _employeeRepository ??= new EmployeeRepository(_repositoryContext);

        public ICustomerRepository Customer => _customerRepository ??= new CustomerRepository(_repositoryContext);

        public IAddressRepository Address => _addressRepository ??= new AddressRepository(_repositoryContext);

        public void Save() => _repositoryContext.SaveChanges();

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
