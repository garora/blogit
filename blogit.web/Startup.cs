using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(blogit.web.Startup))]
namespace blogit.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
