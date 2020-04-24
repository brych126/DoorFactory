using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int DoorQuantity { get; set; }
        public int OrderId { get; set; }
        public int DoorId { get; set; }

        public virtual Doors Door { get; set; }
        public virtual Orders Order { get; set; }
    }
}
