using System;
using ICore.ICore;

namespace Service
{
    public class PublicServiceSite : IPublicServiceSite
    {
        private readonly IServiceProvider _provider;
        public PublicServiceSite(IServiceProvider provider)
        {
            _provider = provider;
        }
        private T GetService<T>()
            where T : class
        {
            var obj = _provider?.GetService(typeof(T)) as T;

            return obj;
        }
        public IUserPublicService User => GetService<IUserPublicService>();
    }
}
