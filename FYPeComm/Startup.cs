using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FYPeComm.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FYPeComm
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
            services.AddDbContext<ProductContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    "adminRoute",
                    "admin",
                    "{area:exists}/{controller}/{action}"
                );

                routes.MapAreaRoute(
                    name: "storeRoute",
                    areaName: "Store",
                    template: "{area:exists}/{constroller}/{action}");
                    
                routes.MapRoute(
                    name: "default",
                    template: "{area=Store}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
