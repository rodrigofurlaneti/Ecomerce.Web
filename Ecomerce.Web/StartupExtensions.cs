﻿using Ecomerce.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Options;

namespace Ecomerce.Web
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplicationBuilder) where TStartup : IStartup
        {
            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                             .AddJsonFile("appsettings."+webApplicationBuilder.Environment.EnvironmentName+".json", true)
                                             .AddEnvironmentVariables().Build();

            var services = new ServiceCollection().AddOptions().Configure<AppSettings>(config.GetSection("ApiSettings")).BuildServiceProvider();

            var appsettings = services.GetService<IOptions<AppSettings>>();

            var startup = Activator.CreateInstance(typeof(TStartup), webApplicationBuilder.Configuration) as IStartup;

            if (startup == null) throw new ArgumentException("Classe Startup.cs inválida!");

            startup.ConfigureServices(webApplicationBuilder.Services);

            var app = webApplicationBuilder.Build();

            startup.Configure(app, app.Environment);

            app.Run();

            return webApplicationBuilder;
        }
    }
}