using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Mvc;
using System.Linq;
using WebApi.Filters;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Logging;
using Microsoft.AspNet.Mvc.Formatters;

namespace WebApi
{
    public class Startup
    {
        public Startup()
        {
            Console.WriteLine("Listening on port 5000");
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilter));

                options.OutputFormatters
                       .OfType<JsonOutputFormatter>()
                       .First()
                       .SerializerSettings
                       .ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
