using BougieCandles.Data;
using BougieCandles.Data.Interfaces;
using BougieCandles.Data.Mocks;
using BougieCandles.Data.Models;
using BougieCandles.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BougieCandles
{
    public class Startup
    {

        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        private readonly IConfigurationRoot _configurationRoot;
        public Startup(IWebHostEnvironment hostingEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
            .AddJsonFile("appsettings.json")
            .Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { //Server configuration
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
            //Authentication, Identity config
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICandleRepository, CandleRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShoppingCart.GetCart(sp));
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
            services.AddControllersWithViews();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            


            //services.AddTransient<ICandleRepository, CandleRepository>();
            //services.AddMvc();
            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<AppDbContext>();
            //services.AddControllersWithViews();
            //services.AddRazorPages();
            //services.AddTransient<ICategoryRepository, CategoryRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller = Home}/{action = Index}/{id?}");
                routes.MapRoute(name: "itemdetails", template: "Item/Details/{itemId?}", defaults: new { Controller = "Item", action = "Details" });
                routes.MapRoute(name: "categoryfilter", template: "Item/{action}/{category?}", defaults: new { Controller = "Item", action = "List" });

            });
            app.UseMvcWithDefaultRoute();

            DbInitializer.Seed(app);
        }
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //        app.UseDatabaseErrorPage();
        //    }
        //    else
        //    {
        //        app.UseExceptionHandler("/Home/Error");
        //        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //        app.UseHsts();
        //    }
        //    app.UseHttpsRedirection();
        //    app.UseStaticFiles();

        //    app.UseRouting();

        //    app.UseAuthentication();
        //    app.UseAuthorization();

        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllerRoute(
        //            name: "default",
        //            pattern: "{controller=Home}/{action=Index}/{id?}");
        //        endpoints.MapRazorPages();
        //    });
        //}
    }
}
