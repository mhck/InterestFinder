using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace InterestFinder.Models
{
    public class Post
    {
        public int PostID { get; set; }
        public int InterestID { get; set; }
        public string Sender { get; set; }

        [DisplayName("Title")]
        public string HeaderText { get; set; }

        [Required, DisplayName("Text")]
        public string ContentText { get; set; }

        [Required, DisplayName("Time posted")]
        public DateTime TimePosted { get; set; }

        public virtual ICollection<Post> Comments { get; set; }
    }
}