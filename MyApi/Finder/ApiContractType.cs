using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyApi.Finder
{
    public class ApiContractType
    {
        public ServiceLifetime Lifetime { get; set; }
        public Type ApiType { get; set; }
        public Type ImplementationType { get; set; }
    }
}
