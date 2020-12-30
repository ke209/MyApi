using ICore;
using System;
using System.IO;
using ICore.ICore;
using ICore.Sites;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Respository;
using Service;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            // create ServiceProvider
            var serviceProvider = services.BuildServiceProvider();
            IMyApi myApi=serviceProvider.GetService(typeof(IMyApi)) as IMyApi;
            Console.WriteLine($"Context:{myApi!.Context.GetHashCode()}");
            Console.WriteLine($"Config:{myApi.Config.GetHashCode()}");
            Console.WriteLine($"Service:{myApi.Service.GetHashCode()}");
            Console.WriteLine($"Respository:{myApi.Respository.GetHashCode()}");

            Console.WriteLine($"RequestId:{myApi.Context.RequestId}");
            Console.WriteLine($"AppSetting:{myApi.Config.AppSetting}");
            Console.WriteLine($"GetUserNameAsync:{myApi.Service.Public.User.GetUserNameAsync(1).Result}");
            Console.WriteLine($"GetEmail:{myApi.Service.User().GetEmail(2)}");
            Console.WriteLine($"Pop:{myApi.Respository.Redis.Pop()}");
            Console.WriteLine($"Pop:{myApi.Respository.UserDataContext().FirstOrDefaultAsync<UserDataContext>(null).Result}");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               //.AddJsonFile($"appsettings.{environmentName}.json", optional: false, true)
               .AddEnvironmentVariables()
               .Build();

            services.AddLogging(builder =>
            {
                //builder.AddConfiguration(configuration.GetSection("Logging"));
                builder.AddConsole();
            });

            services.AddSingleton<IConfiguration>(provider => configuration);
            services.AddScoped<IMyApi, MyApi>();
            services.AddScoped<IConfigSite, ConfigSite>();
            services.AddScoped<IRespositorySite, RespositorySite>();
            services.AddScoped<IRedisRepository, RedisRepository>();
            services.AddScoped<IDbContextRepository<UserDataContext>, DbContextRepository<UserDataContext>>();
            services.AddScoped<IServiceSite, ServiceSite>();
            services.AddScoped<IPublicServiceSite, PublicServiceSite>();
            services.AddScoped<IUserPublicService, UserService>();
            services.AddScoped<ApiInvokeContext>();
        }
    }
}
