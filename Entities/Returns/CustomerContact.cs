using System;

namespace CustomerManagementPortal.Entities.Returns
{
    public class CustomerContact
    {
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
