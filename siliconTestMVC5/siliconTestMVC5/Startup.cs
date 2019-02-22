using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(siliconTestMVC5.Startup))]
namespace siliconTestMVC5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
