using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ICore.ICore;
using ICore.Sites;
using Microsoft.Extensions.DependencyInjection;
using MyApi;
using MyApi.Attribute;

namespace Service
{
    [ExportApi(typeof(IUserService))]
    [ExportApi(typeof(IUserPublicService))]
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
