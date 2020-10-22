using System;
using CustomerManagementPortal.Entities.Enums;
using CustomerManagementPortal.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementPortal.Entities.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Sisi",
                    LastName = "Murlik",
                    Age = 5,
                    Gender = Gender.Female,
                    Email = "sisi.kaczuszka@wp.pl",
                    PhoneNumber = "666666666",
                    AddressId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Amor",
                    LastName = "Murlik",
                    Age = 3,
                    Gender = Gender.Male,
                    Email = "amor.buziaczek@onet.pl",
                    PhoneNumber = "555-555-555",
                    AddressId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Paula",
                    LastName = "Murlik",
                    Age = 17,
                    Gender = Gender.Female,
                    Email = "prywatny.murlik@gmail.com",
                    PhoneNumber = "537843591",
                    AddressId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Kacper",
                    LastName = "Bergański",
                    Age = 21,
                    Gender = Gender.Male,
                    Email = "kacper.berganski@onet.com",
                    PhoneNumber = "720860430",
                    AddressId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Daria",
                    LastName = "Bergańska",
                    Age = 0,
                    Gender = Gender.Female,
                    Email = "",
                    PhoneNumber = "",
                    AddressId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Aleksandra",
                    LastName = "Czerwińska",
                    Age = 28,
                    Gender = Gender.Female,
                    Email = "aleksandra.czerwa@gmail.com",
                    PhoneNumber = "506139325",
                    AddressId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Julia",
                    LastName = "Czerwińska",
                    Age = 20,
                    Gender = Gender.Female,
                    Email = "j.czerwinska@o2.pl",
                    PhoneNumber = "512899657",
                    AddressId = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                }
            );
        }
    }
}