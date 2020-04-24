using System;
using System.Collections.Generic;

namespace DoorFactory.Models
{
    public partial class Provider
    {
        public Provider()
        {
            ProviderOrder = new HashSet<ProviderOrder>();
        }

        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public int CityId { get; set; }

        public virtual Cities City { get; set; }
        public virtual ICollection<ProviderOrder> ProviderOrder { get; set; }
    }
}
