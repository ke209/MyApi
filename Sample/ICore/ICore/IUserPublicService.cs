using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ICore.ICore
{
    public interface IUserPublicService
    {
        Task<string> GetUserNameAsync(int userId);
    }
}
