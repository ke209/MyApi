using Service;

namespace ICore.Sites
{
    public static class ServiceSiteExtension
    {
        public static IUserService User(this IServiceSite site)
        {
            return new UserService();
        }
    }
}
