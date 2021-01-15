using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Generator
{
    static class InterfaceDeclarationExtension
    {
        public static IEnumerable<InterfaceDeclarationSyntax> DescendantsAndSelf(this InterfaceDeclarationSyntax interfaceDeclaration,
            Func<InterfaceDeclarationSyntax, IEnumerable<InterfaceDeclarationSyntax>> childrenFunc)
        {
            yield return interfaceDeclaration;

            var children = childrenFunc(interfaceDeclaration)?.Where(x => x != null).SelectMany(x => x.DescendantsAndSelf(childrenFunc));

            if (children != null)
            {
                foreach (var item in children)
                {
                    yield return item;
                }
            }
        }

        public static SimpleNameSyntax GetSimpleName(this BaseTypeSyntax baseType)
        {
            if (baseType is SimpleBaseTypeSyntax simpleBaseType && simpleBaseType.Type is SimpleNameSyntax simpleName)
                return simpleName;

            return null;
        }

        public static InterfaceDeclarationSyntax GetInterfaceDeclaration(this SimpleNameSyntax simpleName, IEnumerable<InterfaceDeclarationSyntax> list)
        {
            if (simpleName == null)
                return null;

            var result = list.FirstOrDefault(c => c.Identifier.ValueText == simpleName.Identifier.ValueText &&
                c.TypeParameterList?.Parameters.Count ==
                    (simpleName is GenericNameSyntax genericName ? genericName.TypeArgumentList.Arguments.Count : 0));

            return result;
        }

        public static TypeInfo GetTypeInfo(this TypeSyntax typeSyntax)
        {
            if (typeSyntax is GenericNameSyntax g)
                return new TypeInfo { Name = g.Identifier.ValueText, Children = g.TypeArgumentList.Arguments.Select(a => a.GetTypeInfo()).ToList() };
            else
                return new TypeInfo { Name = typeSyntax.ToString() };
        }
    }
}
