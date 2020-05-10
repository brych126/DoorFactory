using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoorFactory.ViewModels
{
    public class CustomerDataViewModel
    {
        public Customers Customer { get; set; }
        public DelieveryInfo DeliveryInfo { get; set; }
        public bool NeedDelivery { get; set; }
        public SelectList Cities { get; set; }
    }
}
