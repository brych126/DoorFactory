using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DoorFactory.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoorFactory.ViewModels
{
    public class DoorOrderViewModel
    {
        public Doors Door { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public int BaseMaterialCategoryID { get; set; }
        public int BaseMaterialID { get; set; }
        public int LockCategoryID { get; set; }
        public int LockID { get; set; }
        public SelectList Colors { get; set; }
        public SelectList DoorCategories { get; set; }
        public SelectList OpeningStyles { get; set; }
        public SelectList StyleTypes { get; set; }
        public SelectList MaterialCategories { get; set; }
        public SelectList LockCategories { get; set; }
        public SelectList BaseMaterials { get; set; }
        public SelectList Locks { get; set; }
    }
}
