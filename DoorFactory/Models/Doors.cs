using System;
using System.Collections.Generic;

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
        public int Width { get; set; }
        public int Height { get; set; }
        public int Thickness { get; set; }
        public decimal Price { get; set; }
        public int DoorsCategoriesId { get; set; }
        public int OpeningStylesId { get; set; }
        public int StyleTypesId { get; set; }
        public string DoorName { get; set; }
        public string Description { get; set; }
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
