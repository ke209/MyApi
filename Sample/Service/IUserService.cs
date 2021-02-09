using Core.Sites;
using MyApi;

namespace Service
{
    [ExtensionMyApi("Core.Sites.IServiceSite","User")]
    public interface IUserService
    {
        string GetEmail(int userId);
    }
}
