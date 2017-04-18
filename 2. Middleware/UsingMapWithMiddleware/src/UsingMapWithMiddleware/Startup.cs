using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UsingMapWithMiddleware
{
    public class Startup
    {
        //#### 
        // Run using "UsingMapWithMiddleware" command so console is displayed!
        // Navigate to http://localhost:5000/customers
        //####
        public Startup(IHostingEnvironment env)
        {
            Console.WriteLine("Listening on port 5000");
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            app.Use(async (context, next) =>
            {
                Console.WriteLine("Standard Middleware Called");
                await next();
            });

            app.Map("/customers", HandleCustomersRoute);

            app.UseMvc();
        }

        private static void HandleCustomersRoute(IApplicationBuilder app)
        {
            app.Run(async context  =>
            {
                await context.Response.WriteAsync("Hit /customers map middleware");
                Console.WriteLine("/Customers Map to Middleware Successful");
            });
        }
    }
}
