using ICore.Sites;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICore
{
    public class MyApi : IMyApi
    {
        private readonly IServiceProvider _provider;
        public MyApi(IServiceProvider provider)
        {
            _provider = provider;
        }
        private T GetService<T>()
            where T : class
        {
            var obj = _provider?.GetService(typeof(T)) as T;

            return obj;
        }

        public IConfigSite Config => GetService<IConfigSite>();

        public IServiceSite Service => GetService<IServiceSite>();

        public IRespositorySite Respository =>  GetService<IRespositorySite>();

        public ApiInvokeContext Context => GetService<ApiInvokeContext>();
    }
}
