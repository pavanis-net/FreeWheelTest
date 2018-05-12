using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FreeWheelTest.Startup))]
namespace FreeWheelTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
