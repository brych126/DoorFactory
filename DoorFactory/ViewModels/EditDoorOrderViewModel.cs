using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;

namespace DoorFactory.ViewModels
{
    public class EditDoorOrderViewModel
    {
        public Doors Door { get; set; }
        public string BaseMaterialCategory { get; set; }
        public string BaseMaterial { get; set; }
        public string LockCategory { get; set; }
        public string Lock { get; set; }
        public string Color { get; set; }
        public string DoorCategory { get; set; }
        public string OpeningStyle { get; set; }
        public string StyleType { get; set; }
        public int DoorPosition { get; set; }
        public int DoorQuantity { get; set; }
    }
}
