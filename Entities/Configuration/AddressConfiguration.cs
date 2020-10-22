using System;
using CustomerManagementPortal.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementPortal.Entities.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address
                {
                    Id = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3"),
                    Country = "Poland",
                    City = "Gdynia",
                    Street = "Filipkowskiego 20A/22",
                    ZipCode = "81578"
                },
                new Address
                {
                    Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                    Country = "Poland",
                    City = "Chwaszczyno",
                    Street = "Buraczana",
                    ZipCode = "80209"
                },
                new Address
                {
                    Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    Country = "Poland",
                    City = "Gdańsk",
                    Street = "Kolarska 8E",
                    ZipCode = "80-180"
                }
            );
        }
    }
}