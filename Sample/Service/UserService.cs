using Core.ICore;
using MyApi;
using System.Threading.Tasks;

namespace Service
{
    [ExportApi(typeof(IUserService))]
    [ExportApi(typeof(IUserPublicService))]
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
