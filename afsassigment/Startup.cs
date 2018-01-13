using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(afsassigment.Startup))]
namespace afsassigment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
