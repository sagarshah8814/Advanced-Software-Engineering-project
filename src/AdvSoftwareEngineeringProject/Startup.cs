using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvSoftwareEngineeringProject.Controllers;
using AdvSoftwareEngineeringProject.Models;
using AdvSoftwareEngineeringProject.Services;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvSoftwareEngineeringProject
{
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        //constructor of startup that gets called when application starts and loads database from appsettings.json
        public Startup(IHostingEnvironment hostingEnvironment)
        {
                _configurationRoot= new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //configure database with given name as DefaultConnection
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //Configure .net identity where student class is an identityuser
            services.AddIdentity<Student,IdentityRole>(config=>
            config.Cookies.ApplicationCookie.LoginPath="/Account/Login")
             .AddEntityFrameworkStores<AppDbContext>();
            //course and student repository class gets called when ICourse and IStudent repositories are instantiated
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddScoped<IMailService,DebugMailService>();
            //configures mvc for application
            services.AddMvc();
            //configures session
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //displays exceptions in the web page
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            //adds html,css and js pages to be recognized by application
            app.UseStaticFiles();
            //adds identity
            app.UseIdentity();
            // adds session
            app.UseSession();
            //adds mvc and configures route for application
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name:"default",
                    template:"{controller}/{action}/{id?}",
                    defaults: new {controller="Home",action="Index"}
                    );
            });
            //calls Dbinitializer and adds data when application starts
            DbInitializer.Seed(app);
           
        }
    }
}
