using Microsoft.Owin;

using Owin;

using PrimitiveObsession.UI;

[assembly: OwinStartup(typeof(Startup))]

namespace PrimitiveObsession.UI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
