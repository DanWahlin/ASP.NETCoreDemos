using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ConfiguringServices.Filters;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace ConfiguringServices
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine("Listening on port 5000");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //Add custom exception filter
                options.Filters.Add(typeof(CustomExceptionFilter));
                
                //Convert null responses from Action to a 204
                options.OutputFormatters.Add(new HttpNoContentOutputFormatter());
            });

            //Remove default Camel Casing for JSON
            services.AddMvcCore().AddJsonFormatters(jsonFormatter =>
            {
                jsonFormatter.ContractResolver = new DefaultContractResolver();
            });

        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseMvc();
        }
    }
}
