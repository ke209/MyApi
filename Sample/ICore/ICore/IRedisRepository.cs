using System;
using System.Collections.Generic;
using System.Text;

namespace ICore.ICore
{
    public interface IRedisRepository
    {
        string Pop();
    }
}
