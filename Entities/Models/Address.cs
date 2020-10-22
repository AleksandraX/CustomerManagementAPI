using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Address
    {
        public Guid Guid { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }
    }
}
