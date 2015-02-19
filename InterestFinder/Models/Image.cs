using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InterestFinder.Models
{
    public class Image
    {
        [Key]
        public int ImageID { get; set; }
    }
}