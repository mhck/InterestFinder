using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InterestFinder.Startup))]
namespace InterestFinder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
