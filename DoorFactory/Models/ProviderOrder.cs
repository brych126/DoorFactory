using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class ProviderOrder
    {
        public ProviderOrder()
        {
            MaterialInOrder = new HashSet<MaterialInOrder>();
        }

        public int ProviderOrderId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime ProviderorderDate { get; set; }
        public short Status { get; set; }
        public int ProviderId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Provider Provider { get; set; }
        public virtual ICollection<MaterialInOrder> MaterialInOrder { get; set; }
    }
}
