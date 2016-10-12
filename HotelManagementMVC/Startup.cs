using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HotelManagementMVC.Startup))]
namespace HotelManagementMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
