using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(InstantMessenger.App_Start.Startup))]

namespace InstantMessenger.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR("/signalr",new HubConfiguration()
            {
                EnableJSONP = true,
                EnableDetailedErrors = true
            });
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
