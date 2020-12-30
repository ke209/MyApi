using System;
using System.Collections.Generic;
using System.Text;

namespace ICore.ICore
{
    public interface IPublicServiceSite:ISite
    {
        IUserPublicService User { get; }
    }
}
