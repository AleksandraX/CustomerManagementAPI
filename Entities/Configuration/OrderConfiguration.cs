using System;
using CustomerManagementPortal.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerManagementPortal.Entities.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasData(
                new Order()
                {
                    Id = new Guid("fc17f474-751b-4f22-b79a-261e27fb4a08"),
                    CreationDate = new DateTime(2020, 11, 01),
                    LastUpdateDate = null,
                    OrderedByCustomerId = new Guid("DC003AA0-8F29-4BE3-A623-69FC9136E9D2"),
                    Price = 200,
                    StatusId = new Guid("c9bf2890-0cdc-4946-adf3-858d616a081f")
                },
                new Order()
                {
                    Id = new Guid("ba5cb36e-3f46-43f8-9798-68bf94aca68e"),
                    CreationDate = new DateTime(2020, 11, 04),
                    LastUpdateDate = null,
                    OrderedByCustomerId = new Guid("C6E963AE-CA9E-4BCB-9C13-A58C2F7B0FFA"),
                    Price = 100,
                    StatusId = new Guid("c9bf2890-0cdc-4946-adf3-858d616a081f")
                },
                new Order()
                {
                    Id = new Guid("3f168c8a-5d53-4ff8-ace8-d54170cd1bdd"),
                    CreationDate = new DateTime(2020, 10, 15),
                    LastUpdateDate = null,
                    OrderedByCustomerId = new Guid("DC003AA0-8F29-4BE3-A623-69FC9136E9D2"),
                    Price = 220,
                    StatusId = new Guid("05b40e38-bbb7-44a8-bca3-19e02361bfb2")
                }
            );
        }
    }
}
