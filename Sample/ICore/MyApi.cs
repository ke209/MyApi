using ICore.Sites;
using Microsoft.Extensions.DependencyInjection;
using MyApi;
using MyApi.Attribute;
using System;

namespace ICore
{
    public class MyApi : SiteBase, IMyApi
    {
        public MyApi(IObjectFactoryBuilder builder) : base(builder)
        { }

        public IConfig Config => GetService<IConfig>("Config");

        public IServiceSite Service => GetService<IServiceSite>("Service");

        public IRespositorySite Respository =>  GetService<IRespositorySite>("Respository");

        public ApiInvokeContext Context => GetService<ApiInvokeContext>("Context");
    }
}
