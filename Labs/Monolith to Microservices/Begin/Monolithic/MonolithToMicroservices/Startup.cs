using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MonolithToMicroservices.Repository;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.Extensions.FileProviders;
using System.IO;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;

namespace MonolithToMicroservices
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

            //Add SqLite support
            services.AddDbContext<CustomersDbContext>(options => {
                options.UseSqlite(Configuration.GetConnectionString("CustomersSqliteConnectionString"));
            });

            services.AddMvc();

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddTransient<CustomersDbSeeder>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            CustomersDbSeeder customersDbSeeder)
        {
            //app.UseFileServer();

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });

            });

            customersDbSeeder.SeedAsync(app.ApplicationServices).Wait();
        }
    }
}
