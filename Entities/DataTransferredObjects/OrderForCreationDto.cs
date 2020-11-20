using System;

namespace CustomerManagementPortal.Entities.DataTransferredObjects
{
    public class OrderForCreationDto
    {
        public Guid OrderedByCustomerId { get; set; }
        public decimal Price { get; set; }
    }
}
