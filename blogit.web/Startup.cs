using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlogIT.Web.Startup))]
namespace BlogIT.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
