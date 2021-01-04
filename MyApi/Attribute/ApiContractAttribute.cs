using Microsoft.Extensions.DependencyInjection;

namespace MyApi.Attribute
{
    public abstract class ApiContractAttribute:System.Attribute
    {
        public ApiContractAttribute(ServiceLifetime lifetime,string name)
        {
            this.Lifetime = lifetime;
            this.Name = name;
        }
        public ServiceLifetime Lifetime { get; }
        public string Name { get; protected set; }
    }
}
