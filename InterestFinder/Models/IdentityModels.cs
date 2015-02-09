using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace InterestFinder.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Nickname { get; set; }
        public IList<Message> Inbox { get; set; }
        public IList<Message> SentMessages { get; set; }
        public IList<Interest> Interests { get; set; }

        public ApplicationUser()
        {
            Inbox = new List<Message>();
            SentMessages = new List<Message>();
            Interests = new List<Interest>();
        }

        public ApplicationUser(string nickname)
        {
            Nickname = nickname;
            Inbox = new List<Message>();
            SentMessages = new List<Message>();
            Interests = new List<Interest>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<InterestFinder.Models.Message> Messages { get; set; }

        public System.Data.Entity.DbSet<InterestFinder.Models.Interest> Interests { get; set; }

        public System.Data.Entity.DbSet<InterestFinder.Models.Post> Posts { get; set; }
    }
}