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
            services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer
                    (Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IGoalRepository, EfGoalRepository>();
            services.AddScoped<IVisionBoardRepository, EfVisionBoardRepository>();
            services.AddControllersWithViews();
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
            app.UseAuthorization();
            //- app.UseEndpoints(endpoints =>
            //- {
            //-     endpoints.MapControllerRoute(
            //-         name: "pagination",
            //-         pattern: "Products/Page{productPage}",
            //-         defaults: new { Controller = "Home", action = "Index" });
            //-     endpoints.MapDefaultControllerRoute();
            //- });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        } // Configure method ends
    } // class ends
} // namespace ends
