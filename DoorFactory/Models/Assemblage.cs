using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Assemblage
    {
        public int AssemblageId { get; set; }
        public DateTime AssemblageDate { get; set; }
        public int EmployeeId { get; set; }
        public int OrderId { get; set; }
        public string Notes { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual Orders Order { get; set; }
    }
}
