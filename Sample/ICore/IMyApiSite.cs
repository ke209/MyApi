using Core.ICore;
using Core.Implement;
using Core.Sites;
using MyApi;

namespace Core
{
    [MyApiSite]
    public interface IMyApiSite
    {
        IConfig Config { get; }
        IServiceSite Service { get; }
        IRespositorySite Respository { get; }
        ApiInvokeContext Context { get; }
    }
}
