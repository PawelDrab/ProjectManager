using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectManager.Startup))]
namespace ProjectManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
