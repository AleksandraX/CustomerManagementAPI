﻿using Contracts;

namespace CustomerManagementPortal.Contracts
{
    public interface IRepositoryManager
    {
        ICompanyRepository Company { get; }
        IEmployeeRepository Employee { get; }
        ICustomerRepository Customer { get; }
        void Save();
    }
}
