using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShvikaNitzani1.Startup))]
namespace ShvikaNitzani1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
