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
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("Visit: http://localhost:8000/api/dataservice/customers/1");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                //Add custom exception filter
                options.Filters.Add(typeof(CustomExceptionFilter));
                
                //Convert null responses from Action to a 204
                options.OutputFormatters.Add(new HttpNoContentOutputFormatter());
            });

            // Demonstrate removing default Camel Casing for JSON for a client
            services.AddMvcCore().AddJsonFormatters(jsonFormatter =>
            {
                jsonFormatter.ContractResolver = new DefaultContractResolver();
            });

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}
