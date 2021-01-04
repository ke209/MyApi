using System;
using ICore.ICore;
using ICore.Sites;
using Microsoft.Extensions.DependencyInjection;
using MyApi;
using MyApi.Attribute;
using Service;

namespace ICore.Sites
{
    public class ServiceSite : SiteBase,IServiceSite
    {
        public ServiceSite(IObjectFactoryBuilder builder) : base(builder)
        { }

        public IPublicServiceSite Public => GetService<IPublicServiceSite>("Public");
    }
}
