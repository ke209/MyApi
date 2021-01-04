using System;
using Microsoft.Extensions.DependencyInjection;

namespace MyApi.Attribute
{
    [AttributeUsage( AttributeTargets.Interface)]
    public class MyApiSiteAttribute: ApiContractAttribute
    {
        public MyApiSiteAttribute(ServiceLifetime lifetime = ServiceLifetime.Singleton,string name=null)
                :base(lifetime,name)
        {
        }

    }
}
