using System.Collections.Generic;

namespace MyApi.Generator
{
    public class BaseClassInfo
    {
        public string Name { get; set; }
        public List<TypeInfo> TypeParametersInfo { get; set; }
    }
}
