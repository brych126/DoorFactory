using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class EmployeeRoles
    {
        public EmployeeRoles()
        {
            Employees = new HashSet<Employees>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
