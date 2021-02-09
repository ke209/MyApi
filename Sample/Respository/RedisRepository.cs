using Core.ICore;
using MyApi;

namespace Respository
{
    [ExportMyApi(typeof(IRedisRepository))]
    public class RedisRepository : IRedisRepository
    {
        public string Pop()
        {
            return "pop";
        }
    }
}
