using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LISMVC.Startup))]
namespace LISMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
