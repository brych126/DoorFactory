using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Materials
    {
        public Materials()
        {
            MaterialInOrder = new HashSet<MaterialInOrder>();
            MaterialsDoor = new HashSet<MaterialsDoor>();
            MatrialInStorage = new HashSet<MatrialInStorage>();
        }

        public int MaterialId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int MaterialCategoryId { get; set; }
        public string Description { get; set; }

        public virtual MaterialsCategory MaterialCategory { get; set; }
        public virtual ICollection<MaterialInOrder> MaterialInOrder { get; set; }
        public virtual ICollection<MaterialsDoor> MaterialsDoor { get; set; }
        public virtual ICollection<MatrialInStorage> MatrialInStorage { get; set; }
    }
}
