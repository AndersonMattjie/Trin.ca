using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Churras.Startup))]
namespace Churras
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
