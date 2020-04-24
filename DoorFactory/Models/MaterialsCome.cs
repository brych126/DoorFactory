using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class MaterialsCome
    {
        public int MaterialsGoneId { get; set; }
        public int MaterialsCount { get; set; }
        public DateTime Datetime { get; set; }
        public int MaterialinorderId { get; set; }
        public int MaterialinstorageId { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employees Employee { get; set; }
        public virtual MaterialInOrder Materialinorder { get; set; }
        public virtual MatrialInStorage Materialinstorage { get; set; }
    }
}
