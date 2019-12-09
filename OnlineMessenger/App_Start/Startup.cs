using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(OnlineMessenger.App_Start.Startup))]

namespace OnlineMessenger.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888


            //app.MapSignalR();
            app.MapSignalR("/signalr", new HubConfiguration()
            {
                EnableJSONP = true,
                EnableDetailedErrors = true
            });
            app.UseCors(CorsOptions.AllowAll);
        }
    }
}
