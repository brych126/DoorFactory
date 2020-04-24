using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class MaterialsDoor
    {
        public int MaterialId { get; set; }
        public int DoorId { get; set; }
        public int MaterialsDoorId { get; set; }
        public double CountMaterial { get; set; }

        public virtual Doors Door { get; set; }
        public virtual Materials Material { get; set; }
    }
}
