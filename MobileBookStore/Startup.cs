using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MobileBookStore.Startup))]
namespace MobileBookStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
