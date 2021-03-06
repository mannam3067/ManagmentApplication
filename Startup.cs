using ManagmentApplication.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
namespace ManagmentApplication
{
    public class Startup
    {
        private IConfiguration _config;


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration config)
        {
            _config = config;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //configuring the dbcontext class
            services.AddDbContextPool<AppDbContext>(option => option.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));
            // here we need to add the EnableEndpointRouting = false otherwise we get the error
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //services.AddMvcCore(option => option.EnableEndpointRouting = false);
            //Configured model classes in services
            services.AddScoped<IEmployeeRepository, SqlEmployeeRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            #region commentedcode
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        //System.Diagnostics.Process.GetCurrentProcess().ProcessName
            //        await context.Response.WriteAsync(_config["MyKey"]);
            //        
            //    });
            //});

            //app.Use(async (context,next) =>
            //{
            //    //await context.Response.WriteAsync("Hello from 1st Middleware");
            //    logger.LogInformation("MW1: Incoming Request");               
            //    await next();
            //    logger.LogInformation("MW1: Outgoing Request");
            //});

            //app.Use(async (context, next) =>
            //{
            //    //await context.Response.WriteAsync("Hello from 1st Middleware");
            //    logger.LogInformation("MW1: Incoming Request");
            //    await next();
            //    logger.LogInformation("MW1: Outgoing Request");
            //});
            #endregion


            // Add UseFileServer file Middleware and replaceing the UseDefaultFiles() and UseStaticFiles()
            //FileServerOptions fileServerOption = new FileServerOptions();
            //fileServerOption.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOption.DefaultFilesOptions.DefaultFileNames.Add("Html/foo.html");
            app.UseFileServer();  //fileServerOption

            //very importent note add UseDefaultFiles middleware must be before to UseStaticFiles
            // Add default Files Middleware   
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("Html/Default.html");
            app.UseDefaultFiles(); //defaultFilesOptions
            // Add Static Files Middleware            
            app.UseStaticFiles();
            //Added Mvc MiddleWare
            app.UseMvcWithDefaultRoute();
            //app.UseMvc();
            app.Run(async (context) =>
            {
                //await context.Response.WriteAsync("Hello from 2nd Middleware");
                //logger.LogInformation("MW3: Request handled and response produced");
                await context.Response.WriteAsync("Hello World");


            });

        }
    }
}
