using System;

namespace CustomerManagementPortal.Entities.RequestFeatures
{
    public class OrderStatusChangeParameters
    {
        public Guid OrderId { get; set; }
        public Guid NewOrderStatusId { get; set; }
    }
}
