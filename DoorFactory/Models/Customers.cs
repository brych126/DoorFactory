using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomersId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
