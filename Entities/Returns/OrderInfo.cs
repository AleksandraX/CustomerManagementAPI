using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerManagementPortal.Entities.Returns
{
    public class OrderInfo
    {
        public Guid Id { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }
        public Guid OrderedByCustomerId { get; set; }
        public string OrderedByCustomerFullName { get; set; }
        public Guid StatusId { get; set; }
    }
}
