using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Site_1.Data;
using Site_1.Data.interfaces;
using Site_1.Data.mocks;
using Site_1.Data.Models;
using Site_1.Data.Repository;

namespace Site_1
{
    public class Startup
    {
        private IConfigurationRoot _confstring;
        public Startup(IWebHostEnvironment hostEnv)
        {
            _confstring = new ConfigurationBuilder().
                SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>
                (options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>();
            services.AddTransient<ICarsCategory, CategoryRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<Service>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); 
            services.AddScoped(sp => ShopCart.GetCart(sp));                     
            services.AddMvc();
            services.AddMemoryCache(); 
            services.AddSession();  
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession(); //new
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: "categoryFilter", "Car/{action}/{category?}",
                    defaults: new { Controller = "Car", action = "List" });//new
            });

            using (var scoupe = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scoupe.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
        }
    }
}
