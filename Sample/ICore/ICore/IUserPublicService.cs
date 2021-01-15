using System.Threading.Tasks;

namespace Core.ICore
{
    public interface IUserPublicService
    {
        Task<string> GetUserNameAsync(int userId);
    }
}
