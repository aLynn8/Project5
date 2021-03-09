using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Project5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Aubrey Farnbach (Wright) Sectino 2 Group 1
namespace Project5
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<BookDBContext>(options =>
           {
               options.UseSqlite(Configuration["ConnectionStrings:BookStoreConnection"]);
           });

            services.AddScoped<IBookRepository, EFBookRepository>();

            services.AddRazorPages();

            //To save cart contents during a user's visit
            services.AddDistributedMemoryCache();
            services.AddSession();
            //Specifies that the same object should be used to satisfy requests for Cart instances.
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            //Specifies that the same object should always be used
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //To save cart contents during a user's visit. All we can store in a session is integers, strings and bytes to store other things we need to use a Json file (convert to it then from it)
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                    "{Category}/{pageNum:int}",
                    new { Controller = "Home", Action = "Index"});

                endpoints.MapControllerRoute("page",
                    "{pageNum:int}",
                    new { Controller = "Home", Action = "Index" });

                endpoints.MapControllerRoute("category",
                    "{category}",
                    new { Controller = "Home", Action = "Index", pageNum = 1 });

                endpoints.MapControllerRoute(
                    "pagination",
                    "Books/{pageNum}",
                    new { Controller = "Home", action = "Index" });

                endpoints.MapDefaultControllerRoute();

                //Setting the url mapping system to handle thiese requests that come in specifically for the razor pages
                endpoints.MapRazorPages();
            });

            SeedData.EnsurePopulated(app);
        }
    }
}
