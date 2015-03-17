using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Narcosis101.Models
{
    public class Camera : Item
    {

        public string Lens { get; set; }
        public string ExposureMeter { get; set; }
        public string ExposureControl { get; set; }


        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Review> reviews { get; set; }
    }
}