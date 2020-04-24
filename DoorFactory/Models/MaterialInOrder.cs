using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class MaterialInOrder
    {
        public MaterialInOrder()
        {
            MaterialsCome = new HashSet<MaterialsCome>();
        }

        public int MaterialinorderId { get; set; }
        public int? Count { get; set; }
        public int? MaterialId { get; set; }
        public int? ProviderOrderId { get; set; }
        public decimal? ProviderPrice { get; set; }

        public virtual Materials Material { get; set; }
        public virtual ProviderOrder ProviderOrder { get; set; }
        public virtual ICollection<MaterialsCome> MaterialsCome { get; set; }
    }
}
