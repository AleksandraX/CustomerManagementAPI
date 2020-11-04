using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementPortal.Entities.Returns
{
    public class AddressWithResidents
    {
        public Guid Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }

        public ICollection<CustomerContact> Residents { get; set; }
    }
}
