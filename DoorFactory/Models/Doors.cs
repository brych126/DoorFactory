using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DoorFactory.Models
{
    public partial class Doors
    {
        public Doors()
        {
            MaterialsDoor = new HashSet<MaterialsDoor>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int DoorId { get; set; }
        [Required(ErrorMessage = "Поле Ширина є обовязковим")]
        [Range(500, 5000,ErrorMessage = "Ширина дверей повинна бути в межах від 0.5 до 5 метрів.")]
        public int Width { get; set; }
        [Required(ErrorMessage = "Поле Висота є обовязковим")]
        [Range(1500, 3000, ErrorMessage = "Висота дверей повинна бути в межах від 1.5 до 3 метрів.")]
        public int Height { get; set; }
        [Required(ErrorMessage = "Поле Товщина є обовязковим")]
        [Range(30, 100, ErrorMessage = "Товщина дверей повинна бути в межах від 3 до 10 сантиметрів.")]
        public int Thickness { get; set; }
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Поле Категорія є обовязковим")]
        public int DoorsCategoriesId { get; set; }
        [Required(ErrorMessage = "Поле Тип відкриття є обовязковим")]
        public int OpeningStylesId { get; set; }
        [Required(ErrorMessage = "Поле Стиль є обовязковим")]
        public int StyleTypesId { get; set; }
        public string DoorName { get; set; }
        [MinLength(5, ErrorMessage = "Текст повинен містити щонайменше 5 символів")]
        [MaxLength(255,ErrorMessage = "Текст не повинен перевищувати 255 символів")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Поле Колір є обовязковим")]
        public int ColorId { get; set; }
        public double Rate { get; set; }
        public virtual Colors Color { get; set; }
        public virtual DoorCategories DoorsCategories { get; set; }
        public virtual OpeningStyles OpeningStyles { get; set; }
        public virtual StyleTypes StyleTypes { get; set; }
        public virtual ICollection<MaterialsDoor> MaterialsDoor { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
