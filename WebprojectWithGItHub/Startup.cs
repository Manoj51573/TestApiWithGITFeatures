using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebprojectWithGItHub.Models.ServiceInterface;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace WebprojectWithGItHub
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
/*      This is an optional method of startup class. It can be used to configure the services that are used by the application.This method calls first when the application is requested for the first time.
        Using this method, we can add the services to the DI container, so services are available as a dependency in controller constructor.*/
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
          //  services.AddSingleton<IProductsService, ProductsService>();
            services.AddScoped<IProductsService, ProductsServiceNewImplementation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //It defines how the application will respond to each HTTP request.We can configure the request pipeline by configuring the middleware.
        //It accepts IApplicationBuilder as a parameter and also it has two optional parameters: IHostingEnvironment and ILoggerFactory.
        //Using this method, we can configure built-in middleware such as routing, authentication, session, etc. as well as third-party middleware.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger) //Microsoft.AspNetCore.Hosting
        {
            if (env.IsDevelopment())
            {
                //When the app runs in the Development environment:
                //Developer Exception Page Middleware(UseDeveloperExceptionPage) reports app runtime errors.
                  app.UseDeveloperExceptionPage();


                #region Custom Middlewere
                //Middleware is software that's assembled into an app pipeline to handle requests and responses. Each component:
                //Chooses whether to pass the request to the next component in the pipeline.
                //Can perform work before and after the next component in the pipeline.
                //Request delegates are used to build the request pipeline.The request delegates handle each HTTP request.
                //Request delegates are configured using Run, Map, and Use extension methods.
                //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-5.0
                /////https://www.youtube.com/watch?v=ALu4jtvjSYw
                /////https://www.youtube.com/watch?v=nt6anXAwfYI

                /* app.Use(async (context, next) =>
                 {
                     logger.LogInformation("MW1:incoming request");
                    //await context.Response.WriteAsync("Hello, from first middlewere!");
                     await next.Invoke();
                     logger.LogInformation("MW1:outgoing response");
                 });

                 app.Use(async (context, next) =>
                 {
                     logger.LogInformation("MW2:incoming request");
                     //  await context.Response.WriteAsync("Hello, second first middlewere!");
                     await next.Invoke();
                     logger.LogInformation("MW2:outgoing response");
                 });

                 app.Run(async (context) =>
                 {
                     logger.LogInformation("MW3:Hello, third and final middlewere! request");
                     await context.Response.WriteAsync("Hello, third and final middlewere!");
                     logger.LogInformation("MW2:Hello, third and final middlewere! response");
                     // await next.Invoke();
                 });*/
                #endregion
            }
            else
            {
                //When the app runs in the Production environment:
                //Exception Handler Middleware(UseExceptionHandler) catches exceptions thrown in the following middlewares.
                //UseExceptionHandler is the first middleware component added to the pipeline. the Exception Handler Middleware catches any exceptions that occur in later calls.
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            //Middleware that is not added when creating a new web app with individual users accounts is commented out.
            //UseCors, UseAuthentication, and UseAuthorization must appear in the order shown.

            //HTTPS Redirection Middleware(UseHttpsRedirection) redirects HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            //Static File Middleware(UseStaticFiles) returns static files and short-circuits further request processing.
            //Static File Middleware is called early in the pipeline so that it can handle requests and short-circuit without going through the remaining components. The Static File Middleware provides no authorization checks. Any files served by Static File Middleware, including those under wwwroot, are publicly available.
            //If the request isn't handled by the Static File Middleware, it's passed on to the Authentication Middleware(UseAuthentication), which performs authentication.Authentication doesn't short-circuit unauthenticated requests. Although Authentication Middleware authenticates requests, authorization (and rejection) occurs only after MVC selects a specific Razor Page or MVC controller and action.
            app.UseStaticFiles();
            // app.UseCookiePolicy();

            //Routing Middleware(UseRouting) to route requests.
           app.UseRouting();
            // app.UseRequestLocalization();
            // app.UseCors();

            //Authentication Middleware(UseAuthentication) attempts to authenticate the user before they're allowed access to secure resources.
            app.UseAuthentication();
//            Authorization Middleware(UseAuthorization) authorizes a user to access secure resources.
           app.UseAuthorization();
            // app.UseSession();
            // app.UseResponseCompression();
            // app.UseResponseCaching();

           
            //Endpoint Routing Middleware(UseEndpoints with MapRazorPages) to add Razor Pages endpoints to the request pipeline.
           app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
       
    }
}
