using System.Collections.Generic;
using System.Linq;

namespace MyApi.Generator
{
    public class TypeInfo
    {
        public string Name { get; set; }
        public List<TypeInfo> Children { get; set; }

        public override string ToString()
        {
            return Name + (Children?.Count > 0 ? $"<{string.Join(", ", Children.Select(a => a.ToString()))}>" : null);
        }

        public TypeInfo Clone()
        {
            return CloneImpl() as TypeInfo;
        }

        protected virtual object CloneImpl()
        {
            return new TypeInfo
            {
                Name = Name,
                Children = Children?.Select(a => a.Clone()).ToList(),
            };
        }
    }
}
