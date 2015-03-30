using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IsActiveExample.Startup))]
namespace IsActiveExample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
