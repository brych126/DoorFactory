using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoorFactory.Models
{
    public partial class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        [Required(ErrorMessage = "Поле Кількість дверей є обовязковим")]
        [Range(1, 5, ErrorMessage = "Кількість дверей повинна бути в межах від 1 до 5")]
        public int DoorQuantity { get; set; }
        public int OrderId { get; set; }
        public int DoorId { get; set; }

        public virtual Doors Door { get; set; }
        public virtual Orders Order { get; set; }
    }
}
