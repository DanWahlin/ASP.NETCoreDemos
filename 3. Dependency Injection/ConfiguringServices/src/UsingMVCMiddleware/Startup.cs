using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNet.Mvc;
using System.Linq;
using ConfiguringServices.Filters;
using Microsoft.Framework.Logging;

namespace ConfiguringServices
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

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseMvc();
        }
    }
}
