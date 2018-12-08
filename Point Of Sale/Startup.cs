using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Point_Of_Sale.Startup))]
namespace Point_Of_Sale
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
