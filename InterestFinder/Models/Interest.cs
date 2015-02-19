using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.IO;

namespace InterestFinder.Models
{
    public class Interest
    {
        public int InterestID { get; set; }
        public string InterestName { get; set; }
        public string Category { get; set; }
        public bool AdultOnly { get; set; }
        public string ImageURL { get; set; }
        public System.Drawing.Image ImageThumbnail { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public void CreateThumbnail()
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(ImageURL);
            ImageThumbnail = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero);
            //thumb.Save(Path.ChangeExtension(ImageURL, "thumb"));
        }
    }
}