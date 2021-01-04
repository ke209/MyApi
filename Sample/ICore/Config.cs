using ICore.Sites;
using Microsoft.Extensions.DependencyInjection;
using MyApi;
using MyApi.Attribute;

namespace ICore
{
    [ExportApi(typeof(IConfig))]
    public class Config : IConfig
    {
        public string AppSetting { get; set; } = "Setting";
    }
}
