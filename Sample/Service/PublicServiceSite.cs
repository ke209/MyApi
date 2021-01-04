using System;
using ICore;
using ICore.ICore;
using Microsoft.Extensions.DependencyInjection;
using MyApi;
using MyApi.Attribute;

namespace Service
{
    public class PublicServiceSite : SiteBase,IPublicServiceSite
    {
        public PublicServiceSite(IObjectFactoryBuilder builder):base(builder)
        { }

        public IUserPublicService User => GetService<IUserPublicService>("User");
    }
}
