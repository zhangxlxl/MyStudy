using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyStudy.Startup))]
namespace MyStudy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
