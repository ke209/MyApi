using System;
using ICore.ICore;
using ICore.Sites;
using Respository;

namespace ICore.Sites
{
    public class RespositorySite : IRespositorySite
    {
        private readonly IServiceProvider _provider;
        public RespositorySite(IServiceProvider provider)
        {
            _provider = provider;
        }
        private T GetService<T>()
            where T : class
        {
            var obj = _provider?.GetService(typeof(T)) as T;

            return obj;
        }
        public IRedisRepository Redis =>GetService<IRedisRepository>();
    }
}
