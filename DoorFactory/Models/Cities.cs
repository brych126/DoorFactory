using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Cities
    {
        public Cities()
        {
            DelieveryInfo = new HashSet<DelieveryInfo>();
            Provider = new HashSet<Provider>();
            Storages = new HashSet<Storages>();
        }

        public int CityId { get; set; }
        public string City { get; set; }

        public virtual ICollection<DelieveryInfo> DelieveryInfo { get; set; }
        public virtual ICollection<Provider> Provider { get; set; }
        public virtual ICollection<Storages> Storages { get; set; }
    }
}
