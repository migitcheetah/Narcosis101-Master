using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Narcosis101.Models
{
    public class Lense : Item
    {
        
        
        public string ExposureMeter { get; set; }
        public string ExposureControl { get; set; }
        public string Millimeters { get; set; }
        public string Fnum { get; set; }
        public string FilterSize { get; set; }


        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
    }
}