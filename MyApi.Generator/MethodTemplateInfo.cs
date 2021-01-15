using System.Collections.Generic;
using System.Linq;

namespace MyApi.Generator
{

    public class MethodTemplateInfo
    {
        public List<ArgumentInfo> ArgumentListInfo { get; set; }
        public string ArgumentList => ArgumentListInfo != null ? string.Join(", ", ArgumentListInfo.Select(y => y.Name)) : null;
        public string ArgumentListWithTypes => ArgumentListInfo != null ? string.Join(", ", ArgumentListInfo.Select(y => $"{y.TypeInfo} {y.Name}")) : null;
        public string ArgumentTypesList => ArgumentListInfo != null ? string.Join(", ", ArgumentListInfo.Select(y => y.TypeInfo.ToString() is var typeName && typeName.EndsWith("?") ? $"ToNullable(typeof({typeName.Remove(typeName.Length - 1)}))" : $"typeof({typeName})")) : null;
        public bool IsMyApiMethod { get; set; }
        public bool IsDispose { get; set; }
        public bool UnsupportedMethod => !IsMyApiMethod && !IsDispose;
        public string Name { get; set; }
        public TypeInfo ReturnTypeInfo { get; set; }
        public string ReturnType => ReturnTypeInfo.ToString();
        public List<string> MethodTypeParameterListInfo { get; set; }
        public string MethodTypeParameters => MethodTypeParameterListInfo != null ? string.Join(", ", MethodTypeParameterListInfo) : null;
        public string MethodTypeParameterList => MethodTypeParameterListInfo != null ? string.Join(", ", MethodTypeParameterListInfo.Select(p => $"typeof({p})")) : null;
        public string MethodTypeParameterNames => MethodTypeParameterListInfo != null ? $"{string.Join(", ", MethodTypeParameterListInfo.Select(p => $"{{typeof({p}).AssemblyQualifiedName}}"))}" : null;
        public string InterfaceName { get; set; }
        public List<string> TypeParametersInfo { get; set; }
        public string TypeParameters => TypeParametersInfo != null ? string.Join(", ", TypeParametersInfo) : null;
    }


    public class ArgumentInfo
    {
        public string Name { get; set; }
        public TypeInfo TypeInfo { get; set; }
    }


}
