using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PluralsightPieCourse.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace PluralsightPieCourse
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
       
        // Think of this as a Dependency Injection Container
        public void ConfigureServices(IServiceCollection services)
        {
            // add entity framework core 
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // notice all you have to do to reference the real db is to swap out the class name

            //services.AddScoped<IPieRepository, MockPieRepository>();
            //services.AddScoped<ICategoryRepository, MockCategoryRepository>();
            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            //shopping cart
            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor();
            services.AddSession();

            // you will also commonly see AddTransient and AddSingleton in place of AddScoped
            
            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // This checks if we are running in dev mode. Go to the props of your project / debug,
            // and you can see environment variables. 
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // middleware components
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession(); // make sure this comes before the routing middleware
            
            app.UseRouting(); //enables mvc to map requests to right code - convention based routing

            // endpoints are places we will be nagivating to
            // this decides what to do with the incoming URI from in the browser
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id:int?}");
            });
        }
    }
}
