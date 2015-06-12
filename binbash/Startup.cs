using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(binbash.Startup))]
namespace binbash
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
