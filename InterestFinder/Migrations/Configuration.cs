namespace InterestFinder.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<InterestFinder.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "InterestFinder.Models.ApplicationDbContext";
        }

        protected override void Seed(InterestFinder.Models.ApplicationDbContext context)
        {
            List<Interest> interestList = new List<Interest> { 
                new Interest { InterestName = "Soccer", Category = "Sports", AdultOnly = false, ImageURL = "soccerimg.jpg", Posts = GeneratePosts(10) }, 
                new Interest { InterestName = "Football", Category = "Sports", AdultOnly = false, ImageURL = "footballimg.jpg" },
                new Interest { InterestName = "Basketball", Category = "Sports", AdultOnly = false, ImageURL = "basketballimg.jpg" },
                new Interest { InterestName = "Hockey", Category = "Sports", AdultOnly = false, ImageURL = "hockeyimg.jpeg" },
                new Interest { InterestName = "Baseball", Category = "Sports", AdultOnly = false, ImageURL = "baseballimg.jpg" },
                new Interest { InterestName = "Grand Theft Auto 5", Category = "Gaming", AdultOnly = false, ImageURL = "gta5img.jpg" },
                new Interest { InterestName = "World of Warcraft", Category = "Gaming", AdultOnly = false, ImageURL = "wowimg.jpg" },
                new Interest { InterestName = "Starcraft", Category = "Gaming", AdultOnly = false, ImageURL = "starcraftimg.jpg" }};
            interestList.ForEach(i => context.Interests.AddOrUpdate(p => p.InterestName, i));
            context.SaveChanges();

            List<Post> postList = new List<Post>
            {
                new Post { HeaderText = "Lorem ipsum dolor sit amet",
                    ContentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    TimePosted = DateTime.Now,
                    InterestID = interestList.Single(s => s.InterestName == "Soccer").InterestID },
                new Post { HeaderText = "Lorem ipsum dolor sit amet",
                    ContentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    TimePosted = DateTime.Now,
                    InterestID = interestList.Single(s => s.InterestName == "Football").InterestID },
                new Post { HeaderText = "Lorem ipsum dolor sit amet",
                    ContentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    TimePosted = DateTime.Now,
                    InterestID = interestList.Single(s => s.InterestName == "Hockey").InterestID }
            };

            foreach (Post post in postList)
            {
                var postsInDb = context.Posts.Where(i => i.InterestID == post.InterestID).FirstOrDefault();
                if (postsInDb == null)
                    context.Posts.Add(post);
            }
        }

        private List<Post> GeneratePosts(int numberOfPosts)
        {
            List<Post> result = new List<Post>();
            for (int i = 0; i < numberOfPosts; i++)
            {
                result.Add(new Post
                {
                    ContentText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                    HeaderText = "Lorem ipsum dolor sit amet",
                    TimePosted = DateTime.Now,
                    InterestID = 1
                });
            }
            return result;
        }
    }
}
