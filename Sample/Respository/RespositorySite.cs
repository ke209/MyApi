using ICore.ICore;
using MyApi;
using MyApi.Attribute;

namespace ICore.Sites
{
    public class RespositorySite : SiteBase,IRespositorySite
    {
        public RespositorySite(IObjectFactoryBuilder builder) : base(builder)
        { }
        public IRedisRepository Redis =>GetService<IRedisRepository>("Redis");
    }
}
