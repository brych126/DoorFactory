using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class DelieveryInfo
    {
        public int DelieveryInfoId { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public short Status { get; set; }
        public int CityId { get; set; }
        public int EmployeeId { get; set; }
        public int OrderId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Employees Employee { get; set; }
        public virtual Orders Order { get; set; }
    }
}
