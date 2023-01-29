using System;
using Hoodie_Shop.Areas.Identity.Data;
using Hoodie_Shop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Hoodie_Shop.Areas.Identity.IdentityHostingStartup))]
namespace Hoodie_Shop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HoodieDb>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HoodieDbConnection")));
                
                services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<HoodieDb>();
                services.AddAuthorization(x =>
                {
                    x.AddPolicy("AdminPolicy", p => p.RequireRole("admins"));
                    x.AddPolicy("customerpolicy", p => p.RequireRole("customers"));
                    x.AddPolicy("customerpolicy", p => p.RequireRole("admins"));
                });


                services.ConfigureApplicationCookie(x =>
                {
                    // if an event occurs during authentication , do this .
                    x.Events = new Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationEvents()
                    {
                        OnRedirectToLogin = y => { y.Response.Redirect("Account/Login"); return Task.CompletedTask; },
                        OnRedirectToAccessDenied = y => { y.Response.Redirect("Account/Login"); return Task.CompletedTask; }
                    };
                });
            });
        }
    }
}
