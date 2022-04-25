using System;
using BrassDragonArchive.Areas.Identity.Data;
using BrassDragonArchive.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(BrassDragonArchive.Areas.Identity.IdentityHostingStartup))]
namespace BrassDragonArchive.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<BrassDragonDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("BrassDragonArchiveContext")));

                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<BrassDragonDbContext>();
            });
        }
    }
}