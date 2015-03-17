using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Narcosis101.Models
{
    public class ReviewViewModel
    {


        public string Name { get; set; }
        public string ReviewText { get; set; }

        public ItemViewModel Item { get; set; }
    }

   
}