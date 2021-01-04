using MyApi.Attribute;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace MyApi.Finder
{
    public class ApiContractType
    {
        public ServiceLifetime Lifetime { get;set; }
        public Type ApiType { get; set; }
        public Type ImplementationType { get; set; }
    }
}
