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
        public virtual ICollection<Post> Posts { get; set; }

        public System.Drawing.Image CreateThumbnail()
        {
            System.Drawing.Image imageThumb = null;
            if (ImageURL != null)
            {
                System.Drawing.Image image = System.Drawing.Image.FromFile(ImageURL);
                imageThumb = image.GetThumbnailImage(120, 120, () => false, IntPtr.Zero); // image scaling
            }
            return imageThumb;
        }
    }
}