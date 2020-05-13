using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;

namespace DoorFactory.ViewModels
{
    public class MaterialsViewModel
    {
        public List<Materials> BaseMaterials { get; set; }
        public List<Materials> Locks { get; set; }
        public List<Colors> Colors { get; set; }
        public List<string> ColorCode { get; set; }


    }
}
