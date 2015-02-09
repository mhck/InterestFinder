using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterestFinder.Models;

namespace InterestFinder.ViewModels
{
    public class InterestDetailData
    {
        public Interest Interest { get; set; }
        public Post PostToCreate { get; set; }

        public List<Post> Posts { get; set; }
    }
}