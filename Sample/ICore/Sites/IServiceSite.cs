using MyApi;

namespace Core.Sites
{
    [MyApiSite]
    public interface IServiceSite : ISite
    {
        IPublicServiceSite Public { get; }
    }
}
