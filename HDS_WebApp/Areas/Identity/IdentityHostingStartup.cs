using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(HDS_WebApp.Areas.Identity.IdentityHostingStartup))]
namespace HDS_WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}