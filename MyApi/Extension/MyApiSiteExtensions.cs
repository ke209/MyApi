using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using MyApi.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using MyApi.Finder;

namespace MyApi
{
    public static class MyApiSiteExtensions
    {
        public static IServiceCollection AddMyApiSite(this IServiceCollection services
            , ContractType myApiSiteTypes = null
            , MyApiSettings settings = null) 
        {
            if (myApiSiteTypes == null)
                myApiSiteTypes = ApiFinder.ScanApiContract();

            foreach (var myApiSiteType in myApiSiteTypes.SiteTypes)
            {
                services.AddSingleton(myApiSiteType.SiteType,provider =>
                {
                    var objectBuilder=ObjectFactoryBuilder.ForType(provider, myApiSiteType.SiteType, settings);
                    return Activator.CreateInstance(myApiSiteType.ImplementationType, objectBuilder);
                });
            }

            foreach (var apiContractType in myApiSiteTypes.ApiTypes)
            {  
                 Register(services,apiContractType.Lifetime, apiContractType.ApiType, apiContractType.ImplementationType);
            }

            return services;
        }

        private static void Register(IServiceCollection services
            , ServiceLifetime lifetime
            , Type apiType
            , Type implementationType)
        {

            if (lifetime == ServiceLifetime.Transient)
            {
                services.AddTransient(apiType, implementationType);
            }
            else if (lifetime == ServiceLifetime.Scoped)
            {
                services.AddScoped(apiType, implementationType);
            }
            else
            {
                services.AddSingleton(apiType, implementationType);
            }
        }
    }
}
