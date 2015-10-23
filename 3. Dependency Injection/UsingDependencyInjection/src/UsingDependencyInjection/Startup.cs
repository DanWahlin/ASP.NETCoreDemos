using System;
using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using BizRules;

namespace UsingMVCMiddleware
{
    //DI article: http://blogs.msdn.com/b/webdev/archive/2014/06/17/dependency-injection-in-asp-net-vnext.aspx
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //Single instance created
            services.AddSingleton<ICalculator, Calculator>();

            //New object created every time it is requested
            services.AddTransient<ITransient, Transient>();

            //New object created for each request (scoped to the request)
            services.AddScoped<IScoped, Scoped>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseMvcWithDefaultRoute();
        }
    }
}
