using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Orders
    {
        public Orders()
        {
            Assemblage = new HashSet<Assemblage>();
            DelieveryInfo = new HashSet<DelieveryInfo>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PaymentDeadline { get; set; }
        public short PaymentStatus { get; set; }
        public int CustomersId { get; set; }
        public int EmployeeId { get; set; }
        public decimal OrderTotalPrice { get; set; }

        public virtual Customers Customers { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual ICollection<Assemblage> Assemblage { get; set; }
        public virtual ICollection<DelieveryInfo> DelieveryInfo { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
