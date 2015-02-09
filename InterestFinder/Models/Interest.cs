using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace InterestFinder.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string InterestName { get; set; }
        public string Category { get; set; }
        public bool AdultOnly { get; set; }
        public string ImageURL { get; set; }
        
        public virtual ICollection<Post> Posts { get; set; }
    }
}