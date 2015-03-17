using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narcosis101.Models
{
    public class LensViewModel
    {

       
        public string ExposureMeter { get; set; }
        public string ExposureControl { get; set; }
        public string Millimeters { get; set; }
        public string Fnum { get; set; }
        public string FilterSize { get; set; }
       
        public ItemViewModel Item { get; set; }
        public ReviewViewModel Review { get; set; }
    }

   
}