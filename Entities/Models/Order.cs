using System;
using CustomerManagementPortal.Entities.Enums;

namespace CustomerManagementPortal.Entities.Models
{
    public class Order : Entity
    {
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Guid OrderedByCustomerId { get; set; }
        public Customer OrderedByCustomer { get; set; }
        public Guid StatusId { get; set; }
        public OrderStatus Status { get; set; }
    }
}
