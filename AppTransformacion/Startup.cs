using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppTransformacion.Startup))]
namespace AppTransformacion
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
