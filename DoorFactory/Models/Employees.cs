using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoorFactory.Models
{
    public partial class Employees
    {
        public Employees()
        {
            Assemblage = new HashSet<Assemblage>();
            DelieveryInfo = new HashSet<DelieveryInfo>();
            MaterialsCome = new HashSet<MaterialsCome>();
            Orders = new HashSet<Orders>();
            ProviderOrder = new HashSet<ProviderOrder>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [Required(ErrorMessage = "Поле 'Імя користувача' є обовязковим")]
        public string Username { get; set; }
        public int RoleId { get; set; }
        [Required(ErrorMessage = "Поле 'Пароль' є обовязковим")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual EmployeeRoles Role { get; set; }
        public virtual ICollection<Assemblage> Assemblage { get; set; }
        public virtual ICollection<DelieveryInfo> DelieveryInfo { get; set; }
        public virtual ICollection<MaterialsCome> MaterialsCome { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<ProviderOrder> ProviderOrder { get; set; }
    }
}
