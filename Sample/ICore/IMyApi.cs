using ICore.Sites;

namespace ICore
{
    public interface IMyApi
    {
        IConfigSite Config { get; }
        IServiceSite Service { get; }
        IRespositorySite Respository { get; }
        ApiInvokeContext Context { get; }
    }
}
