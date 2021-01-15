using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyApi.Finder
{
    public class MyApiSiteType
    {
        public ServiceLifetime Lifetime { get; set; }
        public Type SiteType { get; set; }
        public Type ImplementationType { get; set; }
    }
}
