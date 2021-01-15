using Core.ICore;
using MyApi;

namespace Core.Sites
{
    [MyApiSite]
    public interface IPublicServiceSite : ISite
    {
        IUserPublicService User { get; }
    }
}
