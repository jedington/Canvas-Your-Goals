using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MSSA.Canvas_Your_Goals.Models;

namespace MSSA.Canvas_Your_Goals
{
    public class Startup
    {
        // fields
        public IConfiguration Configuration { get; }
        

        // controllers
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // methods
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options
                .UseSqlServer(System.Environment
                .GetEnvironmentVariable("VisionBoardConnectionString")));
            //- services.AddDbContext<AppDbContext>(options => options
            //-     .UseSqlServer(Configuration
            //-     .GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IGoalRepository, EfGoalRepository>();
            services.AddScoped<ITaskRepository, EfTaskRepository>();
            services.AddScoped<IStepRepository, EfStepRepository>();
            services.AddScoped<IVisionBoardRepository, EfVisionBoardRepository>();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddDistributedMemoryCache();
            services.AddSession(
                //- options =>
                //- {
                //-    options.IdleTimeout = TimeSpan.FromSeconds(10);
                //- }
            );
        } // ConfigureService method ends

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //- endpoints.MapControllerRoute(
                //-     name: "default",
                //-     pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        } // Configure method ends
    } // class ends
} // namespace ends
