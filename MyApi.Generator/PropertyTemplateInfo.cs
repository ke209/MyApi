using System.Collections.Generic;

namespace MyApi.Generator
{
    public class PropertyTemplateInfo
    {
        public bool IsMyApiMethod { get; set; }
        public string Name { get; set; }
        public TypeInfo ReturnTypeInfo { get; set; }
        public string ReturnType => ReturnTypeInfo.ToString();
        public string InterfaceName { get; set; }
        public List<string> TypeParametersInfo { get; set; }
        public string TypeParameters => TypeParametersInfo != null ? string.Join(", ", TypeParametersInfo) : null;
    }

}
