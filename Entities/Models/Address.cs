using System;
using System.Collections.Generic;

namespace CustomerManagementPortal.Entities.Models
{
    public class Address : Entity
    {
        public Guid CountryId { get; set; }
        public Country Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
