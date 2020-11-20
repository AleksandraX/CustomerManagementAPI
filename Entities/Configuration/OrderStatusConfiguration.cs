using System;
using CustomerManagementPortal.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace CustomerManagementPortal.Entities.Configuration
{
    public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
    {
        public void Configure(EntityTypeBuilder<OrderStatus> builder)
        {
            builder.HasData(
                new OrderStatus()
                {
                    Id = new Guid("c9bf2890-0cdc-4946-adf3-858d616a081f"),
                    Name = "New"
                },
                new OrderStatus()
                {
                    Id = new Guid("2f6ad0c2-6ecb-4556-9dc1-eeb0d034d646"),
                    Name = "Confirmed"
                },
                new OrderStatus()
                {
                    Id = new Guid("167ea0e7-f697-456b-affe-eaf206ff2c59"),
                    Name = "Packing"
                },
                new OrderStatus()
                {
                    Id = new Guid("c18b20dd-a2e3-4d65-89fb-8f698d7a70c3"),
                    Name = "OnItsWay"
                },
                new OrderStatus()
                {
                    Id = new Guid("0c391e12-4db3-44b3-ae18-d03daf1e7ca5"),
                    Name = "OutForDelivery"
                },
                new OrderStatus()
                {
                    Id = new Guid("05b40e38-bbb7-44a8-bca3-19e02361bfb2"),
                    Name = "Delivered"
                },
                new OrderStatus()
                {
                    Id = new Guid("aead409d-3c2b-4f38-809f-4b317adfe254"),
                    Name = "Cancelled"
                });
        }
    }
}
