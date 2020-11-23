using System;
using DimensionWeb_App.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(DimensionWeb_App.Areas.Identity.IdentityHostingStartup))]
namespace DimensionWeb_App.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DimensionWeb_AppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DimensionWeb_AppContextConnection")));

                //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    //.AddEntityFrameworkStores<DimensionWeb_AppContext>();//
            });
        }
    }
}