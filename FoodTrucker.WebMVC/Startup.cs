using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodTrucker.WebMVC.Startup))]
namespace FoodTrucker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
