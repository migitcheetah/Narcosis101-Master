using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narcosis101.Models
{
    public class CameraViewModel
    {
        
        public string Lens { get; set; }
        public string ExposureMeter { get; set; }
        public string ExposureControl { get; set; }
        public ItemViewModel Item { get; set; }
        public ReviewViewModel Review { get; set; }
    }

}