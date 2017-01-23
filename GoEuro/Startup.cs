using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoEuro.Startup))]
namespace GoEuro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
