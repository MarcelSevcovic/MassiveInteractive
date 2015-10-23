using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Graph.UI.Startup))]
namespace Graph.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
