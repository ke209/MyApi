using System;
using System.Collections.Generic;
using System.Text;
using MyApi.Attribute;

namespace ICore.ICore
{
    [MyApiSite]
    public interface IPublicServiceSite:ISite
    {
        IUserPublicService User { get; }
    }
}
