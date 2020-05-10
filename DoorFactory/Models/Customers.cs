using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoorFactory.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }
        public int CustomersId { get; set; }
        [Display(Name = "Ім'я")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26})*$",
            ErrorMessage = "Ім'я має містити тільки літери")]
        [Required(ErrorMessage = "Поле 'Імя' є обовязковим")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Ім'я повинне складатися від 2 до 25 символів")]
        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        [RegularExpression(@"^[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26}((\s+|-)[a-zA-Zа-яА-ЯІіЄєЇїҐґ'.`]{1,26})*$",
            ErrorMessage = "Прізвище має містити тільки літери")]
        [Required(ErrorMessage = "Поле 'Прізвище' є обовязковим")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Прізвище повинне складати від 2 до 25 символів")]
        public string LastName { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Неправильний формат електронної пошти")]
        [Required(ErrorMessage = "Поле 'email' є обовязковим")]
        public string Email { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
