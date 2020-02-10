using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using asp_mvc_database_assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_mvc_database_assignment
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) //Accces database
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HandleStudentsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //sevices.AddDefaultIdentity<IdentityOptions>(OptionsBuilderConfigurationExtensions => Options.SignIn.RequireConfirmed)

            //services.AddSingleton<ICarRepository, MockCarRepository>();// very alike a static
            services.AddScoped<IStudentRepo, StudentRepo>();
            services.AddScoped<IAssignmentRepo, AssignmentRepo>();
            services.AddScoped<ICourseRepo, CourseRepo>();
            services.AddScoped<ITeacherRepo, TeacherRepo>();

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Behöver körkort
            //för att köra bilen och kunna kolla om de har ett körkort

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

