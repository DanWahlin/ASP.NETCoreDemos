using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.AspNet.Hosting;
using Microsoft.Dnx.Runtime;

namespace UsingMapWithMiddleware
{
    public class Startup
    {
        //#### 
        // Run using "web" command so console is displayed!
        // Navigate to http://localhost:5000/customers
        //####
        public Startup(IHostingEnvironment env, IApplicationEnvironment appEnv)
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
                next();
            });

            app.Map("/customers", HandleCustomersRoute);

            app.UseMvc();
        }

        private static void HandleCustomersRoute(IApplicationBuilder app)
        {
            app.Run(async context  =>
            {
                Console.WriteLine("/Customers Map to Middleware Successful");
            });
        }
    }
}
