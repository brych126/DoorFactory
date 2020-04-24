using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class MaterialsMovements
    {
        public int MaterialsMovementId { get; set; }
        public int MaterialsCount { get; set; }
        public DateTime? Datetime { get; set; }
        public int? MaterialimstorageIdFrom { get; set; }
        public int? MaterialimstorageIdTo { get; set; }

        public virtual MatrialInStorage MaterialimstorageIdFromNavigation { get; set; }
        public virtual MatrialInStorage MaterialimstorageIdToNavigation { get; set; }
    }
}
