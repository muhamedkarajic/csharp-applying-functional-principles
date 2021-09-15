using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nulls.UI.Startup))]
namespace Nulls.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
