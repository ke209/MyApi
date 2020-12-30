using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICore.ICore;

namespace Service
{
    public class UserService :IUserService, IUserPublicService
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
