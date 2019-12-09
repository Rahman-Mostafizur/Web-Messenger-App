using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineMessenger.Startup))]
namespace OnlineMessenger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
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
