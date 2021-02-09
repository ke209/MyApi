using Core.ICore;
using MyApi;
using System.Threading.Tasks;

namespace Service
{
    [ExportMyApi(typeof(IUserService))]
    [ExportMyApi(typeof(IUserPublicService))]
    public class UserService : IUserService, IUserPublicService
    {
        public string GetEmail(int userId)
        {
            return "ke@163.com";
        }

        public Task<string> GetUserNameAsync(int userId)
        {
            return Task.FromResult("ke");
        }
    }
}
