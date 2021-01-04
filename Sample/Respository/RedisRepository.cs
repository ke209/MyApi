using ICore.ICore;
using Microsoft.Extensions.DependencyInjection;
using MyApi;
using MyApi.Attribute;

namespace Respository
{
    [ExportApi(typeof(IRedisRepository))]
    public class RedisRepository:IRedisRepository
    {
        public string Pop()
        {
            return "pop";
        }
    }
}
