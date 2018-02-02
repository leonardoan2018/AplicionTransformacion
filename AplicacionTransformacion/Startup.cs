using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicacionTransformacion.Startup))]
namespace AplicacionTransformacion
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
