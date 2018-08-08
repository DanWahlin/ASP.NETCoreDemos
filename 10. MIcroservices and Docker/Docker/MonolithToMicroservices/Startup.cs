using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.FileProviders;
using System.IO;
using MonolithToMicroservices.Repository;
using MonolithToMicroservices.Infrastructure;
using MonolithToMicroservices.Models;

namespace MonolithToMicroservices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

            services.AddOptions(); //Add ability to inject IOptions<T> for config data
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddSingleton<IHttpClient, StandardHttpClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Serve wwwroot as root
            app.UseFileServer();

            // Serve /node_modules as a separate root (for packages that use other npm modules client side)
            // Added for convenience for those who don't want to worry about running 'gulp copy:libs'
            // Only use in development mode!!
            //app.UseFileServer(new FileServerOptions()
            //{
            //    // Set root of file server
            //    FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules")),
            //    RequestPath = "/node_modules",
            //    EnableDirectoryBrowsing = false
            //});

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //https://github.com/aspnet/JavaScriptServices/blob/dev/samples/angular/MusicStore/Startup.cs
                routes.MapSpaFallbackRoute("spa-fallback", new { controller = "Home", action = "Index" });

            });
        }
    }
}
