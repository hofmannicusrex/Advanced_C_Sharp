using BrassDragonArchive.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassDragonArchive
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
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;  // Makes the URL lowercase.
                options.AppendTrailingSlash = true;  // Makes the URL end with a trailing forward slash.
            });

            services.AddControllersWithViews();
            //Added use of razor pages - Trever Cluney
            services.AddRazorPages();

            /*
             * To enable injection of DbContext objects, you need to call the AddDbContext() method from within the ConfigureServices() method.
             * Typically, you pass this method a lambda expression that creates a DbContextOptions object. In turn, this object gets passed to
             * the constructor of the DbContext class so it can provide information about the database server. In addition, this lambda expression
             * uses the Configuration property of the Startup class to get the connection string from the appsetting.json file and pass it to
             * the DbContext object.
             * 
             * Once you've configured the dependency injection in the Startup.cs file like this, MVC automatically creates and passes a DbContext
             * object to any controller whose constructor has a DbContext parameter.
             */
            services.AddDbContext<CharacterContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BrassDragonArchiveContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            //Added Authentication for webapp - Trever Cluney
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");
                //Added razor page mapping - Trever Cluney
                endpoints.MapRazorPages();
            });
        }
    }
}
