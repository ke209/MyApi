using System.Collections.Generic;
using System.Linq;

namespace MyApi.Generator
{

    public class ClassTemplateInfo
    {
        public string ConstraintClauses { get; set; }
        public string GeneratedClassSuffix { get; set; }
        public string InterfaceName { get; set; }
        public List<BaseClassInfo> BaseClasses { get; set; }
        public List<MethodTemplateInfo> MethodList { get; set; }
        public List<PropertyTemplateInfo> PropertyList { get; set; }
        public List<ExtensionTemplateInfo> ExtensionList { get; set; }
        public bool HasAnyMethodsWithNullableArguments => MethodList.SelectMany(ml => ml.ArgumentListInfo).Any(y => y.TypeInfo.ToString().EndsWith("?"));
        public string Modifiers { get; set; }
        public string Namespace { get; set; }
        public List<string> TypeParametersInfo { get; set; }
        public string TypeParameters => TypeParametersInfo != null ? string.Join(", ", TypeParametersInfo) : null;
        public List<UsingDeclaration> UsingList { get; set; }
    }
}
