using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class OpeningStyles
    {
        public OpeningStyles()
        {
            Doors = new HashSet<Doors>();
        }

        public int OpeningStylesId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Doors> Doors { get; set; }
    }
}
