using Core.ICore;
using Respository;

namespace Core.Sites
{
    public static class RespositorySiteExtension
    {
        public static IDbContextRepository<UserDataContext> UserDataContext(this IRespositorySite site)
        {
            return new DbContextRepository<UserDataContext>();
        }
    }
}
