using Core.ICore;
using MyApi;

namespace Core.Sites
{
    [MyApiSite]
    public interface IRespositorySite : ISite
    {
        IRedisRepository Redis { get; }
    }
}
