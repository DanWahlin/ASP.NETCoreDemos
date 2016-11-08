using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CustomMiddleware
{
    public class Startup
    {
        //#### 
        // Run using "CustomMiddleware" command so console is displayed!
        // Navigate to http://localhost:5000
        //####
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine("Listening on port 5000");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Information);

            //app.UseMiddleware<UserAgentLoggerMiddleware>();

            //OR

            app.UseUserAgentLogger();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
