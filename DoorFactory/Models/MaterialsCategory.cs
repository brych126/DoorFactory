using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class MaterialsCategory
    {
        public MaterialsCategory()
        {
            Materials = new HashSet<Materials>();
        }

        public int MaterialCategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Materials> Materials { get; set; }
    }
}
