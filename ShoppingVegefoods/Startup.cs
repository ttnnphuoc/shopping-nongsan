using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShoppingVegefoods.Startup))]
namespace ShoppingVegefoods
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
