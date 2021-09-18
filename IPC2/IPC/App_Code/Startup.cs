using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IPC.Startup))]
namespace IPC
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
