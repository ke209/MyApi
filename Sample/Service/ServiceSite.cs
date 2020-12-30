using System;
using ICore.ICore;
using ICore.Sites;
using Service;

namespace ICore.Sites
{
    public class ServiceSite : IServiceSite
    {
        private readonly IServiceProvider _provider;
        public ServiceSite(IServiceProvider provider)
        {
            _provider = provider;
        }
        private T GetService<T>()
            where T : class
        {
            var obj = _provider?.GetService(typeof(T)) as T;

            return obj;
        }

        public IPublicServiceSite Public => GetService<IPublicServiceSite>();
    }
}
