using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Narcosis101.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [StringLength(30, ErrorMessage = "Your Name cannot be longer than 30 characters.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Comments are limited to 255 characters.")]
        public string ReviewText { get; set; }

        public int ItemID { get; set; }

    }
}