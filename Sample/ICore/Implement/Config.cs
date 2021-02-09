using Core.ICore;
using MyApi;

namespace Core.Implement
{
    [ExportMyApi(typeof(IConfig))]
    public class Config : IConfig
    {
        public string AppSetting { get; set; } = "Setting";
    }
}
