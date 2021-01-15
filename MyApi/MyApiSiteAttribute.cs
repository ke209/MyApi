using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyApi
{
    [AttributeUsage(AttributeTargets.Interface)]
    public class MyApiSiteAttribute : ApiContractAttribute
    {
        public MyApiSiteAttribute(ServiceLifetime lifetime = ServiceLifetime.Singleton, string name = null)
                : base(lifetime, name)
        {
        }

    }
}
