using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Colors
    {
        public Colors()
        {
            Doors = new HashSet<Doors>();
        }

        public int ColorId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Doors> Doors { get; set; }
    }
}
