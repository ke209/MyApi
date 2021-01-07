using Microsoft.Build.Framework;
using System.IO;
using Microsoft.Build.Utilities;

namespace MyApi.Generator.Tasks
{
    public class GeneratorSiteStubTask : Task
    {
        public string IntermediateOutputPath { get; set; }
        public string MSBuildRuntimeType { get; set; }
        [Output]
        public string AdditionalCompileFile { get; set; }
        public override bool Execute()
        {
            Log.LogMessage("GeneratorSiteStub Begin");

            var intermediateOutputPath = IntermediateOutputPath;
            var mSBuildRuntimeType = MSBuildRuntimeType;
            var additional = Path.Combine(intermediateOutputPath, "DoubiClass.cs");
            AdditionalCompileFile = Path.GetFullPath(additional);
            File.WriteAllText(AdditionalCompileFile,
                @"using System;
namespace Walterlv.Debug
{
    public class Doubi
    {
        public string Name { get; }
        private Doubi(string name) => Name = name;
        public static Doubi Get() => new Doubi(""吕毅"");
    }
}");

            Log.LogMessage("GeneratorSiteStub End");
            return true;
        }
    }
}
