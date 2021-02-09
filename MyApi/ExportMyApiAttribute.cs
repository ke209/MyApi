using Microsoft.Extensions.DependencyInjection;
using System;

namespace MyApi
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ExportMyApiAttribute : ApiContractAttribute
    {
        public ExportMyApiAttribute(Type apiType, ServiceLifetime lifetime = ServiceLifetime.Scoped, string name = null)
            : base(lifetime, name)
        {
            this.ApiType = apiType;
            if (this.Name == null)
                this.Name = apiType.Name;
        }
        public Type ApiType { get; }
    }


}
