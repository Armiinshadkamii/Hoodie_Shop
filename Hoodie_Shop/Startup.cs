//using WebApplication4.Models;

using Microsoft.AspNetCore.Identity;
using Hoodie_Shop.Areas.Identity.Data;
using Hoodie_Shop.Data;

namespace Hoodie_Shop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication();
            services.AddDbContext<HoodieDb>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)

        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            InitRoles(userManager, roleManager).Wait();
        }
        private async Task InitRoles(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser admin = await userManager.FindByNameAsync("Admin@gmail.com");
            if(admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "Admin@gmail.com",
                    Email = "Admin@gmail.com",
                    EmailConfirmed = true,
                    firstName = "Admin",
                    lastName = "Shadkam"
                };
                await userManager.CreateAsync(admin, "Aa@6581");
            }
            if(await roleManager.RoleExistsAsync("admins")==false)
            {
                await roleManager.CreateAsync(new IdentityRole("admins"));
            }
            if(await roleManager.RoleExistsAsync("customers")==false)
            {
                await roleManager.CreateAsync(new IdentityRole("customers"));
            }
            if( await userManager.IsInRoleAsync(admin,"admins")==false)
            {
                await userManager.AddToRoleAsync(admin, "admins");
            }
        }
    }
}
