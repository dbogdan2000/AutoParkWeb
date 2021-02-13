using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoPark.DAL.Entities;
using AutoPark.DAL.Interfaces;
using AutoPark.DAL.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication
{
    public class Startup
    {
        private readonly AppConfig _config;
        public Startup(IConfiguration configuration)
        {
            _config = new AppConfig(configuration);
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IRepository<VehicleType>, VehiclesTypesRepository >(provider => new VehiclesTypesRepository(_config.ConnectionString));
            services.AddTransient<IRepository<Vehicle>, VehiclesRepository>(provider => new VehiclesRepository(_config.ConnectionString));
            services.AddTransient<IRepository<Part>, PartsRepository>(provider =>
                new PartsRepository(_config.ConnectionString));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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