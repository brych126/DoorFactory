using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class DoorCategories
    {
        public DoorCategories()
        {
            Doors = new HashSet<Doors>();
        }

        public int DoorsCategoriesId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Doors> Doors { get; set; }
    }
}
