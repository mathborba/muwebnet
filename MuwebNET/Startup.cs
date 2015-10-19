using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;

[assembly: OwinStartup(typeof(MuwebNET.Startup))]
namespace MuwebNET
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration.UseSqlServerStorage("WebDbConnection");
            app.UseHangfireDashboard("/admin/web-tasks", new DashboardOptions { AuthorizationFilters = new[] { new HangFireAuthorizationFilter() } });
            app.UseHangfireServer();
        }
    }
}