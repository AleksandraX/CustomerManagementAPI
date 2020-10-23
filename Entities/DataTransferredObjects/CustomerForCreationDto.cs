using System;
using CustomerManagementPortal.Entities.Enums;
using CustomerManagementPortal.Entities.Models;

namespace CustomerManagementPortal.Entities.DataTransferredObjects
{
    public class CustomerForCreationDto
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }
        public Guid AddressId { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public Gender Gender { get; set; }
    }
}
