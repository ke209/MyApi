using System;
using System.Collections.Generic;
using System.Text;
using ICore.ICore;
using MyApi.Attribute;

namespace ICore.Sites
{
    [MyApiSite]
    public interface IRespositorySite:ISite
    {
        IRedisRepository Redis { get; }
    }
}
