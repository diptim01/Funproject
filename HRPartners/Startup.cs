using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HRPartners.Startup))]
namespace HRPartners
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
