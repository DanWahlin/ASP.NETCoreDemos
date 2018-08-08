using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UsingConfiguration
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // Show how to create a memory-based configuration in addition to files/env vars
            var dict = new Dictionary<string, string>
            {
                {"AppSettings:AppName", "Customers App"},
            };

            var builder = new ConfigurationBuilder();
            builder.AddConfiguration(configuration); // Existing configuraiton passed to us (don't want to throw it out!)
            builder.AddInMemoryCollection(dict);

            Configuration = builder.Build();
        }

        IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync($"<strong>Environment:</strong> {env.EnvironmentName}" +
                    $"<br /><strong>Connection String:</strong> {Configuration["ConnectionStrings:DefaultConnection"]}" +
                    $"<br /><strong>In Memory Config (AppName):</strong> {Configuration["AppSettings:AppName"]}" +
                    $"<br /><br /> Switch the environment by changing the ASPNETCORE_ENVIRONMENT value in project settings");
            });
        }
    }
}
