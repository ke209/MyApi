using System;
using System.Collections.Generic;
using System.Text;
using ICore.ICore;

namespace ICore.Sites
{
    public interface IRespositorySite:ISite
    {
        IRedisRepository Redis { get; }
    }
}
