using Ecomerce.Infrastructure.Repository.Profile;
using Ecomerce.Infrastructure.Repository.User;
using Ecomerce.Service.Service.Profile;
using Ecomerce.Service.Service.User;
using Ecomerce.Domain.SeedWork;
using Ecomerce.Infrastructure.Repository.Register;
using Ecomerce.Service.Service.Register;

namespace Ecomerce.Web
{
    public class Startup : IStartup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Domain.SeedWork.ILogger, Logger>();

            services.AddScoped<IProfileRepository, ProfileRepository>();

            services.AddScoped<IProfileService, ProfileService>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IRegisterRepository, RegisterRepository>();

            services.AddScoped<IRegisterService, RegisterService>();

            services.AddControllersWithViews();

        }

        public void Configure(WebApplication webApplication, IWebHostEnvironment webHostEnvironment)
        {
            if (!webApplication.Environment.IsDevelopment())
            {
                webApplication.UseExceptionHandler("/Home/Error");
                webApplication.UseHsts();
            }
            webApplication.UseHttpsRedirection();
            webApplication.UseStaticFiles();
            webApplication.UseRouting();
            webApplication.UseAuthorization();
            webApplication.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            webApplication.Run();
        }
    }
}