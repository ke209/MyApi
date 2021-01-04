using ICore.Sites;
using MyApi.Attribute;

namespace ICore
{
    [MyApiSite]
    public interface IMyApi
    {
        IConfig Config { get; }
        IServiceSite Service { get; }
        IRespositorySite Respository { get; }
        ApiInvokeContext Context { get; }
    }
}
