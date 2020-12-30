using ICore.ICore;

namespace ICore.Sites
{
    public interface IServiceSite:ISite
    {
        IPublicServiceSite Public { get; }
    }
}
