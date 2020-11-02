using System;
using CustomerManagementPortal.Entities.Enums;

namespace CustomerManagementPortal.Entities.Returns
{
    public class CustomerListItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
    }
}
