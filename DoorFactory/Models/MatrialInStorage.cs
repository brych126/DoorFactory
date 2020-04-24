using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class MatrialInStorage
    {
        public MatrialInStorage()
        {
            MaterialsCome = new HashSet<MaterialsCome>();
            MaterialsMovementsMaterialimstorageIdFromNavigation = new HashSet<MaterialsMovements>();
            MaterialsMovementsMaterialimstorageIdToNavigation = new HashSet<MaterialsMovements>();
        }

        public int MaterialinstorageId { get; set; }
        public int Count { get; set; }
        public int StorageId { get; set; }
        public int MaterialId { get; set; }

        public virtual Materials Material { get; set; }
        public virtual Storages Storage { get; set; }
        public virtual ICollection<MaterialsCome> MaterialsCome { get; set; }
        public virtual ICollection<MaterialsMovements> MaterialsMovementsMaterialimstorageIdFromNavigation { get; set; }
        public virtual ICollection<MaterialsMovements> MaterialsMovementsMaterialimstorageIdToNavigation { get; set; }
    }
}
