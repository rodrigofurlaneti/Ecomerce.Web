using Ecomerce.Web.Context;
using Ecomerce.Web.Helpers;
using Ecomerce.Web.Model;
using Microsoft.EntityFrameworkCore;

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
            services.AddControllers();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddDbContext<ApplicationDbContext>(option => option
                    .UseSqlServer(Configuration.GetSection("ConnectionString")["DefaultConnection"]));

            services.AddHttpContextAccessor();

            services.AddOptions();
        
            services.AddMvc();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            services.AddScoped(sp => ShoppingCart.GetShoppingCart(sp));

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
