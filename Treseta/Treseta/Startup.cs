using Microsoft.Owin;
using Owin;
using Treseta;

namespace Treseta
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
