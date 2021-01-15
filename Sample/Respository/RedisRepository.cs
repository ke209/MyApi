using Core.ICore;
using MyApi;

namespace Respository
{
    [ExportApi(typeof(IRedisRepository))]
    public class RedisRepository : IRedisRepository
    {
        public string Pop()
        {
            return "pop";
        }
    }
}
