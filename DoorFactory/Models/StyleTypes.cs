using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class StyleTypes
    {
        public StyleTypes()
        {
            Doors = new HashSet<Doors>();
        }

        public int StyleTypesId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Doors> Doors { get; set; }
    }
}
