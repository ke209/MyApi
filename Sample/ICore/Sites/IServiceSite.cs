using ICore.ICore;
using Microsoft.Extensions.DependencyInjection;
using MyApi.Attribute;

namespace ICore.Sites
{
    [MyApiSite]
    public interface IServiceSite:ISite
    {
        IPublicServiceSite Public { get; }
    }
}
