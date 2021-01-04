using Microsoft.Extensions.DependencyModel;
using MyApi.Attribute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MyApi.Finder
{
    public class ApiFinder
    {
        public static ContractType ScanApiContract()
        {
            var contractType = new ContractType
            {
                ApiTypes = new List<ApiContractType>(),
                SiteTypes = new List<MyApiSiteType>()
            };

            var assemblyList = new List<Assembly>();
            string[] filters = new string[8]
            {
                "mscorlib",
                "netstandard",
                "dotnet",
                "api-ms-win-core",
                "runtime.",
                "System",
                "Microsoft",
                "Window"
            };

            DependencyContext dependencyContext = DependencyContext.Default;
            if (dependencyContext != null)
            {
                List<string> assemblyNames = new List<string>();
                string[] array = dependencyContext.CompileLibraries
                        .SelectMany<CompilationLibrary, string>(
                            (Func<CompilationLibrary, IEnumerable<string>>)(m => (IEnumerable<string>)m.Dependencies.Select(r => r.Name)))
                        .Distinct<string>()
                        .Select<string, string>((Func<string, string>)(m => m.Replace(".dll", "")))
                        .OrderBy<string, string>((Func<string, string>)(m => m))
                        .ToArray<string>();
                if (array.Length != 0)
                {
                    assemblyNames = ((IEnumerable<string>)array).Select(name => new
                    {
                        name = name,
                        i = name.LastIndexOf('/') + 1
                    }).Select(p => p.name.Substring(p.i, p.name.Length - p.i))
                        .Distinct<string>()
                        .Where((Func<string, bool>)(name =>
                           !((IEnumerable<string>)filters).Any<string>(new Func<string, bool>(name.StartsWith))))
                        .OrderBy<string, string>((Func<string, string>)(m => m)).ToList<string>();
                }

                foreach (string file in assemblyNames)
                {
                    AssemblyName assemblyRef = new AssemblyName(file);
                    try
                    {
                        assemblyList.Add(Assembly.Load(assemblyRef));
                    }
                    catch (FileNotFoundException ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            foreach (var assembly in assemblyList)
            {
                foreach (var type in assembly.GetTypes().Where(r=>r.IsInterface))
                {
                    foreach (var apiContractAttribute in type.GetCustomAttributes(true)
                                                            .Where(r => r is MyApiSiteAttribute)
                                                            .Cast<MyApiSiteAttribute>())
                    {
                        contractType.SiteTypes.Add(new MyApiSiteType
                        {
                            SiteType = type,
                            Lifetime = apiContractAttribute.Lifetime,
                        });

                    }
                }
            }



            foreach (var assembly in assemblyList)
            {
                foreach (var type in assembly.GetTypes().Where(r => r.IsClass))
                {
                    foreach (var siteType in contractType.SiteTypes)
                    {
                        if (siteType.SiteType.IsAssignableFrom(type))
                        {
                            siteType.ImplementationType = type;
                        }
                    }
                    foreach (var exportApiAttribute in type.GetCustomAttributes(true)
                                                            .Where(r => r is ExportApiAttribute)
                                                            .Cast<ExportApiAttribute>())
                    {
                        contractType.ApiTypes.Add(new ApiContractType()
                        {
                            Lifetime = exportApiAttribute.Lifetime,
                            ApiType = exportApiAttribute.ApiType,
                            ImplementationType = type
                        });

                    }
                }
            }
            return contractType;
        }
    }
}
