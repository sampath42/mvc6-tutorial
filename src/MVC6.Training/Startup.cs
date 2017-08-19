using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Formatters;
using MVC6.Training.Filters;

namespace MVC6.Training
{
    public interface IFoo { string GetFoo(); }
    public class Foo : IFoo
    {
        MyConfig _config;
        public Foo(MyConfig config)
        {
            _config = config;
        }
        public string GetFoo()
        {
            return _config.AppName;
        }
    }

    public class MyConfig
    {
        public string AppName { get; set; }
    }

    public class Startup
    {
        IConfigurationRoot config;
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", false)
                .AddEnvironmentVariables();

            config = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new MyConfig { AppName = config.GetSection("app:appName").Value });
            services.AddSingleton<LogFilter>();
            services.AddTransient<IFoo, Foo>();
            services.AddTransient<ILog, Log>();

            //services.AddScoped<IFoo, Foo>();  

            services.AddMvc(options =>
            {
                // will use with web api
                //options.OutputFormatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.Xml.d())
                //options.RespectBrowserAcceptHeader = true;

                //options.Filters.Add     

            }).AddViewOptions(options =>
            {
                //options.ViewEngines.Add
                //options.HtmlHelperOptions
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Map("/mvc6", helloApp =>
            {
                helloApp.Run(async (HttpContext context) =>
                {
                    await context.Response.WriteAsync("Hello ASP.NET MVC 6");
                });
            });

            //loggerFactory.AddConsole();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseMiddleware();

            //app.Run(async (context) =>
            //{
            //    var foo = context.RequestServices.GetRequiredService<IFoo>();
            //    await context.Response.WriteAsync(foo.GetFoo());
            //});
        }
    }
}
