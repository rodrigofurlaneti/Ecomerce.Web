using Ecomerce.Web.Helpers;
using Microsoft.AspNetCore.Http;
using System;

namespace Ecomerce.Web;
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            services.AddOptions();
        
            services.AddMvc();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped(sp => ShoppingCartHelper.GetShoppingCart(sp));
            
            services.AddControllersWithViews();

            services.AddMemoryCache();
            
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
