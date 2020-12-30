using System;
using System.Collections.Generic;
using System.Text;

namespace ICore.Sites
{
    public interface IConfigSite:ISite
    {
        string AppSetting { get; set; }
    }
}
