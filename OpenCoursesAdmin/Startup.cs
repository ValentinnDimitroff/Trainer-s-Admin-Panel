namespace OpenCoursesAdmin
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using OpenCoursesAdmin.Data;
    using OpenCoursesAdmin.Services.Implementations;
    using OpenCoursesAdmin.Services;
    using OpenCoursesAdmin.Data.Models;
    using OpenCoursesAdmin.Profiles;
    using OpenCoursesAdmin.Services.Interfaces;
    using AutoMapper;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OCADbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<OCADbContext>()
                .AddDefaultTokenProviders();

            Mapper.Initialize(cfg => cfg.AddProfile<SoftUniProfile>());

            services.AddTransient<IExternalRequester, ExternalRequester>();
            services.AddTransient<IQuizsService, QuizsService>();
            services.AddTransient<IConfigurationService, ConfigurationService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<ISurveyService, SurveyService>();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=" + nameof(MVC.Course) + "}/{action=" + nameof(MVC.Course.All) + "}/{id?}");
            });
        }
    }
}
