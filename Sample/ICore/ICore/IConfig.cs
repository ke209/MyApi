using System;
using System.Collections.Generic;
using System.Text;
using MyApi.Attribute;

namespace ICore.Sites
{
    public interface IConfig
    {
        string AppSetting { get; set; }
    }
}
