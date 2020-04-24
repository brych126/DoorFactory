using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;

namespace DoorFactory.ViewModels
{
    public class OrdersViewModel
    {
        public Orders Order { get; set; }
        public int DoorsAmount { get; set; }
    }
}
