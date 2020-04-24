using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Storages
    {
        public Storages()
        {
            MatrialInStorage = new HashSet<MatrialInStorage>();
        }

        public int StorageId { get; set; }
        public string Adress { get; set; }
        public int? CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<MatrialInStorage> MatrialInStorage { get; set; }
    }
}
