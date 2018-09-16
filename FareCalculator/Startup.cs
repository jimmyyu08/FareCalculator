using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FareCalculator.Startup))]
namespace FareCalculator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
