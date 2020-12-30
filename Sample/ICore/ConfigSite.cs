using System;
using System.Collections.Generic;
using System.Text;
using ICore.Sites;

namespace ICore
{
    public class ConfigSite : IConfigSite
    {
        public string AppSetting { get; set; } = "Setting";
    }
}
