using Core;
using Core.Sites;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyApi;
using Respository;
using System;
using System.IO;

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
            IMyApiSite myApi = serviceProvider.GetService(typeof(IMyApiSite)) as IMyApiSite;
            Console.WriteLine($"Context:{myApi!.Context.GetHashCode()}");
            Console.WriteLine($"Config:{myApi!.Config.GetHashCode()}");
            Console.WriteLine($"Service:{myApi!.Service.GetHashCode()}");
            Console.WriteLine($"Respository:{myApi!.Respository.GetHashCode()}");

            Console.WriteLine($"RequestId:{myApi.Context.RequestId}");
            Console.WriteLine($"AppSetting:{myApi.Config.AppSetting}");
            Console.WriteLine($"GetUserNameAsync:{myApi.Service.Public.User.GetUserNameAsync(1).Result}");
            Console.WriteLine($"GetEmail:{myApi.Service.User().GetEmail(2)}");
            Console.WriteLine($"Redis:{myApi.Respository.Redis.Pop()}");
            Console.WriteLine($"DataContext:{myApi.Respository.UserDataContext().FirstOrDefaultAsync<UserDataContext>(null).Result}");
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddEnvironmentVariables()
               .Build();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });

            services.AddMyApiSite();

        }
    }
}
