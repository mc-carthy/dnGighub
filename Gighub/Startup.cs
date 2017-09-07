using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gighub.Startup))]
namespace Gighub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
