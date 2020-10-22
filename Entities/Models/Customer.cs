using System;


namespace Entities.Models
{
    public class Customer
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Address Address { get; set; }

        public int PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
